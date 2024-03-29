﻿using System;
using System.Diagnostics.CodeAnalysis;

using AutoMapper;

using Azure;
using Azure.Search.Documents;

using DFC.App.ExploreCareers.AzureSearch;
using DFC.App.ExploreCareers.BingSpellCheck;
using DFC.App.ExploreCareers.Configuration;
using DFC.App.ExploreCareers.Cosmos;
using DFC.App.ExploreCareers.Data.Contracts;
using DFC.App.ExploreCareers.Data.Models.ContentModels;
using DFC.App.ExploreCareers.HostedServices;
using DFC.App.ExploreCareers.Services.CacheContentService;
using DFC.Compui.Cosmos;
using DFC.Compui.Cosmos.Contracts;
using DFC.Compui.Subscriptions.Pkg.Netstandard.Extensions;
using DFC.Compui.Telemetry;
using DFC.Content.Pkg.Netcore.Data.Models.ClientOptions;
using DFC.Content.Pkg.Netcore.Data.Models.PollyOptions;
using DFC.Content.Pkg.Netcore.Extensions;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DFC.App.ExploreCareers
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        private const string CosmosDbSharedContentConfigAppSettings = "Configuration:CosmosDbConnections:JobCategoryContent";

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