using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using AutoMapper;

using Azure;
using Azure.Search.Documents;

using DFC.App.ExploreCareers.AzureSearch;
using DFC.App.ExploreCareers.BingSpellCheck;
using DFC.App.ExploreCareers.Configuration;
using DFC.App.ExploreCareers.Cosmos;
using DFC.App.ExploreCareers.Data.Contracts;
using DFC.App.ExploreCareers.Data.Models.ContentModels;
using DFC.App.ExploreCareers.GraphQl;
using DFC.App.ExploreCareers.HostedServices;
using DFC.App.ExploreCareers.Services.CacheContentService;
using DFC.Common.SharedContent.Pkg.Netcore;
using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure;
using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using DFC.Common.SharedContent.Pkg.Netcore.RequestHandler;
using DFC.Compui.Cosmos;
using DFC.Compui.Cosmos.Contracts;
using DFC.Compui.Subscriptions.Pkg.Netstandard.Extensions;
using DFC.Compui.Telemetry;
using DFC.Content.Pkg.Netcore.Data.Models.ClientOptions;
using DFC.Content.Pkg.Netcore.Data.Models.PollyOptions;
using DFC.Content.Pkg.Netcore.Extensions;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using RestSharp;

namespace DFC.App.ExploreCareers
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        private const string CosmosDbSharedContentConfigAppSettings = "Configuration:CosmosDbConnections:JobCategoryContent";
        private const string RedisCacheConnectionStringAppSettings = "Cms:RedisCacheConnectionString";
        private const string GraphApiUrlAppSettings = "Cms:GraphApiUrl";
        private const string StaxSqlUrlAppSettings = "Configuration:StaxConnections:StaxSqlConnectionString";

        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.configuration = configuration;
            this.env = env;
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
            services.AddStackExchangeRedisCache(options => { options.Configuration = configuration.GetSection(RedisCacheConnectionStringAppSettings).Get<string>(); });

            services.AddHttpClient();
            services.AddSingleton<IGraphQLClient>(s =>
            {
                var option = new GraphQLHttpClientOptions()
                {
                    EndPoint = new Uri(configuration.GetSection(GraphApiUrlAppSettings).Get<string>()),

                    HttpMessageHandler = new CmsRequestHandler(s.GetService<IHttpClientFactory>(), s.GetService<IConfiguration>(), s.GetService<IHttpContextAccessor>()),
                };
                var client = new GraphQLHttpClient(option, new NewtonsoftJsonSerializer());
                return client;
            });

            services.AddSingleton<IRestClient>(s =>
            {
                var option = new RestClientOptions()
                {
                    BaseUrl = new Uri(configuration.GetSection(StaxSqlUrlAppSettings).Get<string>()),
                    ConfigureMessageHandler = handler => new CmsRequestHandler(s.GetService<IHttpClientFactory>(), s.GetService<IConfiguration>(), s.GetService<IHttpContextAccessor>()),
                };
                JsonSerializerSettings defaultSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    DefaultValueHandling = DefaultValueHandling.Include,
                    TypeNameHandling = TypeNameHandling.None,
                    NullValueHandling = NullValueHandling.Ignore,
                    Formatting = Formatting.None,
                    ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                };

                var client = new RestClient(option);
                return client;
            }

);

            services.AddSingleton<ISharedContentRedisInterfaceStrategy<JobProfileCategoriesResponse>, JobCategoryQueryStrategy>();
            services.AddSingleton<ISharedContentRedisInterfaceStrategy<JobProfilesResponse>, JobProfilesByCategoryQueryStrategy>();

            services.AddSingleton<ISharedContentRedisInterfaceStrategyFactory, SharedContentRedisStrategyFactory>();

            services.AddScoped<ISharedContentRedisInterface, SharedContentRedis>();

            var cosmosDbConnectionSharedContent = configuration.GetSection(CosmosDbSharedContentConfigAppSettings).Get<CosmosDbConnection>();
            services.AddDocumentServices<JobCategoryContentItemModel>(cosmosDbConnectionSharedContent, env.IsDevelopment());

            services.AddApplicationInsightsTelemetry();
            services.AddHttpContextAccessor();
            services.AddHostedServiceTelemetryWrapper();
            services.AddSubscriptionBackgroundService(configuration);
            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddSingleton(configuration.GetSection(nameof(CmsApiClientOptions)).Get<CmsApiClientOptions>() ?? new CmsApiClientOptions());
            services.AddSingleton(configuration.GetSection(nameof(SpellCheckApiClientOptions)).Get<SpellCheckApiClientOptions>() ?? new SpellCheckApiClientOptions());
            var searchClientOptions = configuration.GetSection(nameof(JobProfileSearchClientOptions)).Get<JobProfileSearchClientOptions>() ?? new JobProfileSearchClientOptions();
            services.AddTransient(sp => new SearchClient(new Uri(searchClientOptions.BaseAddress), searchClientOptions.IndexName, new AzureKeyCredential(searchClientOptions.ApiKey)));

            services.AddTransient<ICacheReloadService, CacheReloadService>();
            services.AddTransient<IWebhooksService, WebhooksService>();
            services.AddTransient<IJobCategoryDocumentService, JobCategoryDocumentService>();
            services.AddTransient<IAzureSearchService, AzureSearchService>();
            services.AddTransient<IGraphQlService, GraphQlService>();
            services.AddTransient<ISharedContentRedisInterface, SharedContentRedis>();
            services.AddTransient<ISharedContentRedisInterfaceStrategyFactory, SharedContentRedisStrategyFactory>();

            if (bool.TryParse(configuration["Configuration:ReloadCache"], out bool reload) && reload)
            {
                services.AddHostedService<CacheReloadBackgroundService>();
            }

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
                })
                .AddNewtonsoftJson()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }
    }
}