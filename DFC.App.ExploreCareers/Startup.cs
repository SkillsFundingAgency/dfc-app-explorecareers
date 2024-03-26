using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using AutoMapper;
using Azure;
using Azure.Search.Documents;
using DFC.App.ExploreCareers.AzureSearch;
using DFC.App.ExploreCareers.BingSpellCheck;
using DFC.App.ExploreCareers.Configuration;
using DFC.App.ExploreCareers.GraphQl;
using DFC.Common.SharedContent.Pkg.Netcore;
using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure;
using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using DFC.Common.SharedContent.Pkg.Netcore.RequestHandler;
using DFC.Compui.Telemetry;
using DFC.Content.Pkg.Netcore.Data.Models.PollyOptions;
using DFC.Content.Pkg.Netcore.Extensions;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using RestSharp;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace DFC.App.ExploreCareers
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        private const string RedisCacheConnectionStringAppSettings = "Cms:RedisCacheConnectionString";
        private const string StaxGraphApiUrlAppSettings = "Cms:GraphApiUrl";
        private const string SqlApiUrlAppSettings = "Cms:SqlApiUrl";
        private const string WorkerThreadsConfigAppSettings = "ThreadSettings:WorkerThreads";
        private const string IocpThreadsConfigAppSettings = "ThreadSettings:IocpThreads";

        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;
        private readonly ILogger<Startup> logger;

        public Startup(IConfiguration configuration, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            this.configuration = configuration;
            this.env = env;
            this.logger = logger;
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMapper mapper)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

                // add the default route
                endpoints.MapControllerRoute("default", "{controller=Health}/{action=Ping}");
            });
            mapper?.ConfigurationProvider.AssertConfigurationIsValid();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureMinimumThreads();

            services.AddStackExchangeRedisCache(options => { options.Configuration = configuration.GetSection(RedisCacheConnectionStringAppSettings).Get<string>(); });

            services.AddHttpClient();
            services.AddSingleton<IGraphQLClient>(s =>
            {
                var option = new GraphQLHttpClientOptions()
                {
                    EndPoint = new Uri(configuration.GetSection(StaxGraphApiUrlAppSettings).Get<string>() ?? throw new ArgumentNullException()),

                    HttpMessageHandler = new CmsRequestHandler(s.GetService<IHttpClientFactory>(), s.GetService<IConfiguration>(), s.GetService<IHttpContextAccessor>() ?? throw new ArgumentNullException()),
                };
                var client = new GraphQLHttpClient(option, new NewtonsoftJsonSerializer());
                return client;
            });

            services.AddSingleton<ISharedContentRedisInterfaceStrategy<JobProfileCategoriesResponseExploreCareers>, JobCategoryQueryStrategyExploreCareers>();
            services.AddSingleton<ISharedContentRedisInterfaceStrategy<JobProfilesResponse>, JobProfilesByCategoryQueryStrategy>();

            services.AddSingleton<ISharedContentRedisInterfaceStrategyFactory, SharedContentRedisStrategyFactory>();

            services.AddScoped<ISharedContentRedisInterface, SharedContentRedis>();

            services.AddApplicationInsightsTelemetry();
            services.AddHttpContextAccessor();
            services.AddHostedServiceTelemetryWrapper();
            services.AddAutoMapper(typeof(Startup).Assembly);

            var searchClientOptions = configuration.GetSection(nameof(JobProfileSearchClientOptions)).Get<JobProfileSearchClientOptions>() ?? new JobProfileSearchClientOptions();
            services.AddTransient(sp => new SearchClient(new Uri(searchClientOptions.BaseAddress), searchClientOptions.IndexName, new AzureKeyCredential(searchClientOptions.ApiKey)));
            services.AddSingleton(configuration.GetSection(nameof(SpellCheckApiClientOptions)).Get<SpellCheckApiClientOptions>() ?? new SpellCheckApiClientOptions());

            services.AddTransient<IAzureSearchService, AzureSearchService>();
            services.AddTransient<IGraphQlService, GraphQlService>();
            services.AddTransient<ISharedContentRedisInterface, SharedContentRedis>();
            services.AddTransient<ISharedContentRedisInterfaceStrategyFactory, SharedContentRedisStrategyFactory>();

            var policyOptions = configuration.GetSection("Policies").Get<PolicyOptions>() ?? new PolicyOptions();
            var policyRegistry = services.AddPolicyRegistry();
            services
                .AddPolicies(policyRegistry, nameof(SpellCheckApiClientOptions), policyOptions)
                .AddHttpClient<ISpellCheckService, SpellCheckService, SpellCheckApiClientOptions>(
                    nameof(SpellCheckApiClientOptions),
                    nameof(PolicyOptions.HttpRetry),
                    nameof(PolicyOptions.HttpCircuitBreaker));

            services.AddApiServices(configuration, policyRegistry);

            services.AddMvc(config =>
                {
                    config.RespectBrowserAcceptHeader = true;
                    config.ReturnHttpNotAcceptable = true;
                });
        }

        private void ConfigureMinimumThreads()
        {
            var workerThreads = Convert.ToInt32(configuration[WorkerThreadsConfigAppSettings]);

            var iocpThreads = Convert.ToInt32(configuration[IocpThreadsConfigAppSettings]);

            if (ThreadPool.SetMinThreads(workerThreads, iocpThreads))
            {
                logger.LogInformation(
                    "ConfigureMinimumThreads: Minimum configuration value set. IOCP = {0} and WORKER threads = {1}",
                    iocpThreads,
                    workerThreads);
            }
            else
            {
                logger.LogWarning("ConfigureMinimumThreads: The minimum number of threads was not changed");
            }
        }
    }
}