using AutoMapper;
using DFC.App.ExploreCareers.AutoMapperProfiles;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DFC.App.ExploreCareers.IntegrationTests.AutoMapperTests
{
    [Trait("Category", "Integration - Automapper")]
    public class AutoMapperProfileTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> factory;

        public AutoMapperProfileTests(CustomWebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public void AutoMapperProfileConfigurationForContentPageModelProfileReturnSuccess()
        {
            // Arrange
            factory.CreateClient();
            var mapper = factory.Server.Host.Services.GetRequiredService<IMapper>();

            // Act
            mapper.ConfigurationProvider.AssertConfigurationIsValid<SearchResultsViewModelProfile>();

            // Assert
            Assert.True(true);
        }

        [Fact]
        public void AutoMapperProfileConfigurationForAllProfilesReturnSuccess()
        {
            // Arrange
            factory.CreateClient();
            var mapper = factory.Server.Host.Services.GetRequiredService<IMapper>();

            // Act
            mapper.ConfigurationProvider.AssertConfigurationIsValid();

            // Assert
            Assert.True(true);
        }
    }
}
