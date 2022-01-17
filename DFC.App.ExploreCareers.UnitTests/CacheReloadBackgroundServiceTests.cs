using System;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.Data.Contracts;
using DFC.App.ExploreCareers.HostedServices;
using DFC.Compui.Telemetry.HostedService;
using DFC.Content.Pkg.Netcore.Data.Models.ClientOptions;

using FakeItEasy;

using Microsoft.Extensions.Logging;

using Xunit;

namespace DFC.App.ExploreCareers.UnitTests
{
    public class CacheReloadBackgroundServiceTests
    {
        private readonly ICacheReloadService sharedContentCacheReloadService = A.Fake<ICacheReloadService>();
        private readonly ILogger<CacheReloadBackgroundService> logger = A.Fake<ILogger<CacheReloadBackgroundService>>();
        private readonly IHostedServiceTelemetryWrapper wrapper = A.Fake<IHostedServiceTelemetryWrapper>();

        [Fact]
        public async Task CacheReloadBackgroundServiceStartsAsyncCompletesSuccessfully()
        {
            // Arrange
            A.CallTo(() => wrapper.Execute(A<Func<Task>>.Ignored, A<string>.Ignored)).Returns(Task.CompletedTask);
            var serviceToTest = new CacheReloadBackgroundService(logger, new CmsApiClientOptions { BaseAddress = new Uri("http://somewhere.com") }, sharedContentCacheReloadService, wrapper);

            // Act
            await serviceToTest.StartAsync(default);

            // Assert
            A.CallTo(() => wrapper.Execute(A<Func<Task>>.Ignored, A<string>.Ignored)).MustHaveHappenedOnceExactly();
            serviceToTest.Dispose();
        }

        [Fact]
        public async Task CacheReloadBackgroundServiceStartsAsyncThrowsException()
        {
            // Arrange
            A.CallTo(() => wrapper.Execute(A<Func<Task>>.Ignored, A<string>.Ignored)).Returns(Task.FromException(new Exception("An Exception")));
            var serviceToTest = new CacheReloadBackgroundService(logger, new CmsApiClientOptions { BaseAddress = new Uri("http://somewhere.com") }, sharedContentCacheReloadService, wrapper);

            // Act
            // Assert
            await Assert.ThrowsAsync<Exception>(async () => await serviceToTest.StartAsync(default));
            serviceToTest.Dispose();
        }
    }
}
