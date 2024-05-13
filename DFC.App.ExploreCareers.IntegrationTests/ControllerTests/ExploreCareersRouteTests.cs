using System;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Common;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using FakeItEasy;

using FluentAssertions;

using Xunit;
using Constants = DFC.Common.SharedContent.Pkg.Netcore.Constant.ApplicationKeys;

namespace DFC.App.ExploreCareers.IntegrationTests.ControllerTests
{
    [Trait("Category", "ExploreCareers Controller Integration Tests")]
    public class ExploreCareersRouteTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> factory;

        private ISharedContentRedisInterface FakeSharedContentRedisInterface { get; } = A.Fake<ISharedContentRedisInterface>();

        public ExploreCareersRouteTests(CustomWebApplicationFactory<Startup> factory) =>
            this.factory = factory;

        [Fact]
        public async Task GetBodyEndpointReturnSuccessAndCorrectContentType()
        {
            // Arrange
            string category = "something";
            var uri = new Uri($"/explore-careers/body", UriKind.Relative);
            var client = GetClient();

            var jobCategory = new JobProfileCategory
            {
                DisplayText = category,
                PageLocation = new PageLocation
                {
                    FullUrl = string.Empty,
                    UrlName = category
                }
            };

            var jobProfileCategoryArray = new JobProfileCategory[] { jobCategory };

            var jobProfileCategoriesResponse = new JobProfileCategoriesResponseExploreCareers
            {
                JobProfileCategories = jobProfileCategoryArray
            };

            A.CallTo(() => factory.FakeSharedContentRedisInterface.GetDataAsync<JobProfileCategoriesResponseExploreCareers>(Constants.ExploreCareersJobProfileCategories, "PUBLISHED", 4))
                .Returns(jobProfileCategoriesResponse);

            // Act
            var response = await client.GetAsync(uri);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be(MediaTypeNames.Text.Html);
        }

        [Fact]
        public async Task GetHeadEndpointReturnSuccessAndCorrectContentType()
        {
            // Arrange
            var uri = new Uri($"/explore-careers/head", UriKind.Relative);
            var client = GetClient();

            // Act
            var response = await client.GetAsync(uri);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be(MediaTypeNames.Text.Html);
        }

        [Fact]
        public async Task GetBodyTopEndpointReturnSuccessAndCorrectContentType()
        {
            // Arrange
            var uri = new Uri($"/explore-careers/bodytop", UriKind.Relative);
            var client = GetClient();

            // Act
            var response = await client.GetAsync(uri);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be(MediaTypeNames.Text.Html);
        }

        private HttpClient GetClient()
        {
            var client = factory.CreateClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(MediaTypeNames.Text.Html));
            return client;
        }
    }
}
