using AutoMapper;
using DFC.App.ExploreCareers.ApiService;
using DFC.App.ExploreCareers.ApiService.Extensions;
using DFC.App.ExploreCareers.AzureSearch;
using DFC.App.ExploreCareers.Data.Contracts;
using DFC.App.ExploreCareers.Data.Models;
using DFC.App.ExploreCareers.Extensions;
using DFC.App.ExploreCareers.HostedServices;
using DFC.App.ExploreCareers.HttpClientPolicies;
using DFC.App.ExploreCareers.Models;
using DFC.App.ExploreCareers.Services.CacheContentService;
using DFC.App.ExploreCareers.Services.EventProcessorService;
using DFC.Compui.Cosmos;
using DFC.Compui.Cosmos.Contracts;
using DFC.Compui.Subscriptions.Pkg.Netstandard.Extensions;
using DFC.Compui.Telemetry;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;

namespace DFC.App.ExploreCareers
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        private const string CosmosDbContentPagesConfigAppSettings = "Configuration:CosmosDbConnections:ContentPages";

        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;
        private static readonly string _corsPolicy = "CorsPolicy";

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

            app.UseCors(_corsPolicy);
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
            var cosmosDbConnectionContentPages = configuration.GetSection(CosmosDbContentPagesConfigAppSettings).Get<CosmosDbConnection>();
            services.AddDocumentServices<JobCategory>(cosmosDbConnectionContentPages, env.IsDevelopment());

            services.AddApplicationInsightsTelemetry();
            services.AddHttpContextAccessor();
            services.AddTransient<IEventMessageService<JobCategory>, EventMessageService<JobCategory>>();
            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddHostedServiceTelemetryWrapper();
            services.AddSubscriptionBackgroundService(configuration);
            services.AddTransient<IWebhooksService, WebhooksService>();

            if (bool.Parse(configuration["ExploreCareers:LoadDataOnStartup"]))
            {
                services.AddHostedService<CacheReloadBackgroundService>();
            }

            services.AddTransient<IApiExtensions, ApiExtensions>();

            services.AddSingleton(configuration.GetSection(nameof(JobCategoryApiClientOptions)).Get<JobCategoryApiClientOptions>());
            services.AddSingleton(configuration.GetSection(nameof(JobProfileSearchClientOptions)).Get<JobProfileSearchClientOptions>());
            services.AddSingleton(configuration.GetSection(nameof(JobCategorySearchClientOptions)).Get<JobCategorySearchClientOptions>());
            services.Configure<ExploreCareersSettings>(configuration.GetSection(nameof(ExploreCareersSettings)));


            services.AddCors(options =>
            {
                options.AddPolicy(_corsPolicy,
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            const string AppSettingsPolicies = "Policies";
            var policyOptions = configuration.GetSection(AppSettingsPolicies).Get<PolicyOptions>() ?? new PolicyOptions();
            var policyRegistry = services.AddPolicyRegistry();

            services
                .AddPolicies(policyRegistry, nameof(JobCategoryApiClientOptions), policyOptions)
                .AddHttpClient<IApiDataService<JobCategoryApiClientOptions>, ApiDataService<JobCategoryApiClientOptions>, JobCategoryApiClientOptions>(configuration, nameof(JobCategoryApiClientOptions), nameof(PolicyOptions.HttpRetry), nameof(PolicyOptions.HttpCircuitBreaker));

            services.AddPolicies(policyRegistry, nameof(JobProfileSearchClientOptions), policyOptions)
                .AddHttpClient<IAzureSearchService<JobProfileSearchClientOptions>,
                    AzureSearchService<JobProfileSearchClientOptions>, JobProfileSearchClientOptions>(configuration, nameof(JobProfileSearchClientOptions), nameof(PolicyOptions.HttpRetry), nameof(PolicyOptions.HttpCircuitBreaker));

            services.AddPolicies(policyRegistry, nameof(JobCategorySearchClientOptions), policyOptions)
                .AddHttpClient<IAutoCompleteService<JobCategorySearchClientOptions>,
                    AutoCompleteService<JobCategorySearchClientOptions>, JobCategorySearchClientOptions>(configuration, nameof(JobCategorySearchClientOptions), nameof(PolicyOptions.HttpRetry), nameof(PolicyOptions.HttpCircuitBreaker));

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