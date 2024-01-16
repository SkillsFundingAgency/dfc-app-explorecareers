using System;
using System.Linq;
using System.Net.Http;

using Azure.Search.Documents;

using DFC.App.ExploreCareers.AzureSearch;
using DFC.App.ExploreCareers.BingSpellCheck;
using DFC.App.ExploreCareers.Data.Contracts;
using DFC.App.ExploreCareers.Data.Models.ContentModels;
using DFC.App.ExploreCareers.GraphQl;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Compui.Cosmos.Contracts;

using FakeItEasy;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DFC.App.ExploreCareers.IntegrationTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
        where TStartup : class
    {
        internal SearchClient FakeClient { get; } = A.Fake<SearchClient>();

        internal IDocumentService<JobCategoryContentItemModel> FakeDocumentService { get; } = A.Fake<IDocumentService<JobCategoryContentItemModel>>();

        internal IWebhooksService FakeWebhookService { get; } = A.Fake<IWebhooksService>();

        internal ISpellCheckService FakeSpellCheckService { get; } = A.Fake<ISpellCheckService>();

        internal IAzureSearchService FakeAzureSearchService { get; } = A.Fake<IAzureSearchService>();

        internal IGraphQlService FakeGraphQlService { get; } = A.Fake<IGraphQlService>();

        internal ISharedContentRedisInterface FakeSharedContentRedisInterface { get; } = A.Fake<ISharedContentRedisInterface>();

        internal new HttpClient CreateClient()
        {
            var opts = new WebApplicationFactoryClientOptions { AllowAutoRedirect = false };
            return CreateClient(opts);
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ConfigureServices(services =>
            {
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings-test.json", optional: true, reloadOnChange: true)
                    .Build();

                services.AddSingleton<IConfiguration>(configuration);
            });

            builder.ConfigureTestServices(services =>
            {
                var hostedServices = services.Where(descriptor =>
                    descriptor.ServiceType == typeof(IHostedService) ||
                    descriptor.ServiceType == typeof(ICosmosRepository<>) ||
                    descriptor.ServiceType == typeof(IWebhooksService) ||
                    descriptor.ServiceType == typeof(IDocumentService<>) ||
                    descriptor.ServiceType == typeof(SearchClient) ||
                    descriptor.ServiceType == typeof(IAzureSearchService) ||
                    descriptor.ServiceType == typeof(ISharedContentRedisInterface) ||
                    descriptor.ServiceType == typeof(IGraphQlService))
                .ToList();

                foreach (var service in hostedServices)
                {
                    services.Remove(service);
                }

                services.AddTransient(sp => FakeClient);
                services.AddTransient(sp => FakeDocumentService);
                services.AddTransient(sp => FakeWebhookService);
                services.AddTransient(sp => FakeSpellCheckService);
                services.AddTransient(sp => FakeAzureSearchService);
                services.AddTransient(sp => FakeSharedContentRedisInterface);
                services.AddTransient(sp => FakeGraphQlService);
            });
        }
    }
}
