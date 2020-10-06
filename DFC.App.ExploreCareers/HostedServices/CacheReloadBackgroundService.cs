using DFC.App.ExploreCareers.Data.Contracts;
using DFC.Compui.Telemetry.HostedService;
using System;
using DFC.App.ExploreCareers.ApiService.Extensions;

namespace DFC.App.ExploreCareers.HostedServices
{
    using DFC.App.ExploreCareers.Data.Models;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using System.Threading;
    using System.Threading.Tasks;

    public class CacheReloadBackgroundService : IHostedService
    {
        private readonly ILogger<CacheReloadBackgroundService> logger;
        private readonly IApiExtensions apiExtensions;
        private readonly IEventMessageService<JobCategory> eventMessageService;
        private readonly IHostedServiceTelemetryWrapper hostedServiceTelemetryWrapper;

        public CacheReloadBackgroundService(ILogger<CacheReloadBackgroundService> logger, IApiExtensions apiExtensions, IEventMessageService<JobCategory> eventMessageService, IHostedServiceTelemetryWrapper hostedServiceTelemetryWrapper)
        {
            this.logger = logger;
            this.apiExtensions = apiExtensions;
            this.eventMessageService = eventMessageService;
            this.hostedServiceTelemetryWrapper = hostedServiceTelemetryWrapper;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Cache reload started");
            var jobCategories = await apiExtensions.LoadDataAsync().ConfigureAwait(false);
            await hostedServiceTelemetryWrapper.Execute(() => eventMessageService.DeleteAllAsync(), nameof(CacheReloadBackgroundService)).ConfigureAwait(false);

            await hostedServiceTelemetryWrapper.Execute(() => eventMessageService.CreateOrUpdateAsync(new JobCategory { Id = Guid.NewGuid(), Html = jobCategories, Version = Guid.NewGuid() }), nameof(CacheReloadBackgroundService)).ConfigureAwait(false);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Cache reload stopped");

            return Task.CompletedTask;
        }
    }
}
