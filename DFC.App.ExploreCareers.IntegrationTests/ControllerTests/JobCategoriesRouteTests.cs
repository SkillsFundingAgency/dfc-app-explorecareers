using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.AzureSearch;
using DFC.App.ExploreCareers.Data.Models.ContentModels;
using DFC.App.ExploreCareers.ViewModels;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles.JobProfileCategory;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
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

        //[Fact]
        //public async Task GetBodyEndpointReturnSuccessAndCorrectContentType()
        //{
            // Arrange
            //string category = "something";
            //var uri = new Uri($"/job-categories/{category}/body", UriKind.Relative);
            //var client = factory.CreateClient();
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(MediaTypeNames.Text.Html));

           // var jobCategory = new JobProfileCategory
            //{
             //   DisplayText = category,
             //   PageLocation = new PageLocation
             //   {
             //       FullUrl = string.Empty,
             //       UrlName = category
             //   }
            //};

            //var jobProfileCategoryArray = new JobProfileCategory[] { jobCategory };

            ///A.CallTo(() => factory.FakeSharedContentRedisInterface.GetDataAsync<JobProfileCategoriesResponse>("JobProfiles/Categories"))
               // .Returns(new JobProfileCategoriesResponse
                //{
                  //  JobProfileCategories = jobProfileCategoryArray
                //});

            //A.CallTo(() => factory.FakeDocumentService.GetAllAsync(A<string>._)).Returns(new List<JobCategoryContentItemModel>
            //{
              //  new JobCategoryContentItemModel { CanonicalName = category, Title = category }
            //});

           // A.CallTo(() => factory.FakeGraphQlService.GetJobProfilesByCategoryAsync(category)).Returns(new List<JobProfileIndex>
            //{
              //  new JobProfileIndex { Title = "Title" }
            //});
            // Act
            //var response = await client.GetAsync(uri);

            // Assert
            //response.StatusCode.Should().BeOneOf(HttpStatusCode.OK);
            ////response//.Content.Headers.ContentType.MediaType.Should().Be(MediaTypeNames.Text.Html);
        //}

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

        //[Fact]
       // public async Task GetBreadcrumbEndpointReturnSuccessAndCorrectContentType()
       // {
            // Arrange
           // string category = "something";
           // var uri = new Uri($"/job-categories/{category}/breadcrumb", UriKind.Relative);
           // var client = factory.CreateClient();
           // client.DefaultRequestHeaders.Accept.Clear();
           // client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(MediaTypeNames.Text.Html));

           // var jobCategory = new JobProfileCategory
           // {
            //    DisplayText = category,
            //    PageLocation = new PageLocation
            //    {
             //       FullUrl = string.Empty,
            //        UrlName = category
           //    }
           // };

          //  var jobProfileCategoryArray = new JobProfileCategory[] { jobCategory };

          //  var jobProfileCategoriesResponse = new JobProfileCategoriesResponse
            //{
           //     JobProfileCategories = jobProfileCategoryArray
           // };

            //A.CallTo(() => factory.FakeSharedContentRedisInterface.GetDataAsync<JobProfileCategoriesResponse>("JobProfiles/Categories"))
            //    .Returns(jobProfileCategoriesResponse);

          // A.CallTo(() => factory.FakeDocumentService.GetAllAsync(A<string>._)).Returns(new List<JobCategoryContentItemModel>
           // {
            //    new JobCategoryContentItemModel { CanonicalName = category, Title = category }
           // });

            // Act
            //var response = await client.GetAsync(uri);

            // Assert
           // response.StatusCode.Should().Be(HttpStatusCode.OK);
           // response.Content.Headers.ContentType.MediaType.Should().Be(MediaTypeNames.Text.Html);
       // }
    }
}
