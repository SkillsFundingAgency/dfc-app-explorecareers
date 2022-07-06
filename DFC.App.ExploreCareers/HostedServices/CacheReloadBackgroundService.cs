using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.Data.Contracts;
using DFC.Compui.Telemetry.HostedService;
using DFC.Content.Pkg.Netcore.Data.Models.ClientOptions;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DFC.App.ExploreCareers.HostedServices
{
    [ExcludeFromCodeCoverage]
    public class CacheReloadBackgroundService : BackgroundService
    {
        private readonly ILogger<CacheReloadBackgroundService> logger;
        private readonly CmsApiClientOptions cmsApiClientOptions;
        private readonly ICacheReloadService cacheReloadService;
        private readonly IHostedServiceTelemetryWrapper hostedServiceTelemetryWrapper;

        public CacheReloadBackgroundService(
            ILogger<CacheReloadBackgroundService> logger,
            CmsApiClientOptions cmsApiClientOptions,
            ICacheReloadService sharedContentCacheReloadService,
            IHostedServiceTelemetryWrapper hostedServiceTelemetryWrapper)
        {
            this.logger = logger;
            this.cmsApiClientOptions = cmsApiClientOptions;
            this.hostedServiceTelemetryWrapper = hostedServiceTelemetryWrapper;
            this.cacheReloadService = sharedContentCacheReloadService;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Cache reload started");

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Cache reload stopped");

            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                if (cmsApiClientOptions.BaseAddress is null)
                {
                    logger.LogInformation($"CMS Api Client Base Address is null, skipping Cache Reload");
                }

                logger.LogInformation($"Executing Telemetry wrapper with service {nameof(cacheReloadService)}");

                var task = hostedServiceTelemetryWrapper.Execute(async () => await cacheReloadService.Reload(stoppingToken), nameof(CacheReloadBackgroundService));
                await task;

                if (!task.IsCompletedSuccessfully)
                {
                    logger.LogInformation($"An error occurred in the {nameof(hostedServiceTelemetryWrapper)}");

                    if (task.Exception != null)
                    {
                        logger.LogError(task.Exception.ToString());
                        throw task.Exception;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}
