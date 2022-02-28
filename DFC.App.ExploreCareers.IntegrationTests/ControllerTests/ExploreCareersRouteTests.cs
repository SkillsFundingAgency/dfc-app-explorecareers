using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.Data.Models.ContentModels;

using FakeItEasy;

using FluentAssertions;

using Xunit;

namespace DFC.App.ExploreCareers.IntegrationTests.ControllerTests
{
    [Trait("Category", "ExploreCareers Controller Integration Tests")]
    public class ExploreCareersRouteTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> factory;

        public ExploreCareersRouteTests(CustomWebApplicationFactory<Startup> factory) =>
            this.factory = factory;

        [Fact]
        public async Task GetBodyEndpointReturnSuccessAndCorrectContentType()
        {
            // Arrange
            string category = "something";
            var uri = new Uri($"/explore-careers/body", UriKind.Relative);
            var client = GetClient();

            A.CallTo(() => factory.FakeDocumentService.GetAllAsync(A<string>._)).Returns(new List<JobCategoryContentItemModel>
            {
                new JobCategoryContentItemModel { CanonicalName = category, Title = category }
            });

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
