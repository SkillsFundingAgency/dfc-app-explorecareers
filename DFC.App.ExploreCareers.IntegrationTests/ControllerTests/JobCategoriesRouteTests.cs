using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.AzureSearch;
using DFC.App.ExploreCareers.Data.Models.ContentModels;

using FakeItEasy;

using FluentAssertions;

using Xunit;

namespace DFC.App.ExploreCareers.IntegrationTests.ControllerTests
{
    [Trait("Category", "JobCategories Controller Integration Tests")]
    public class JobCategoriesRouteTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> factory;

        public JobCategoriesRouteTests(CustomWebApplicationFactory<Startup> factory) =>
            this.factory = factory;

        [Fact]
        public async Task GetBodyEndpointReturnSuccessAndCorrectContentType()
        {
            // Arrange
            string category = "something";
            var uri = new Uri($"/job-categories/{category}/body", UriKind.Relative);
            var client = factory.CreateClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(MediaTypeNames.Text.Html));

            A.CallTo(() => factory.FakeDocumentService.GetAllAsync(A<string>._)).Returns(new List<JobCategoryContentItemModel>
            {
                new JobCategoryContentItemModel { CanonicalName = category, Title = category }
            });
            A.CallTo(() => factory.FakeAzureSearchService.GetProfilesByCategoryAsync(category)).Returns(new List<JobProfileIndex>
            {
                new JobProfileIndex{ Title = "Title" }
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
            string category = "something";
            var uri = new Uri($"/job-categories/{category}/head", UriKind.Relative);
            var client = factory.CreateClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(MediaTypeNames.Text.Html));

            // Act
            var response = await client.GetAsync(uri);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be(MediaTypeNames.Text.Html);
        }

        [Fact]
        public async Task GetBreadcrumbEndpointReturnSuccessAndCorrectContentType()
        {
            // Arrange
            string category = "something";
            var uri = new Uri($"/job-categories/{category}/breadcrumb", UriKind.Relative);
            var client = factory.CreateClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(MediaTypeNames.Text.Html));

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
    }
}
