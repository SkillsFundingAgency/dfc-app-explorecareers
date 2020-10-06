using DFC.App.ExploreCareers.Models.AzureSearch;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace DFC.App.ExploreCareers.UnitTests.ControllerTests.SearchResultsControllerTests
{
    public class SearchResultsControllerTests : BaseSearchResultsControllerTests
    {
        [Fact]
        public async Task PostBodyRetunsOk()
        {
            var controller = BuildSearchResultsController();

            A.CallTo(() => FakeAzureSearchService.Search(A<string>.Ignored, A<int>.Ignored)).Returns(
                new AzureSearchJobProfileModel
                {
                    TotalPages = 1,
                    DocumentTotal = 2,
                    Value = new List<JobProfile> { new JobProfile { Title = "test" }, },
                });

            await controller.Post("dev").ConfigureAwait(false);

            A.CallTo(() => FakeAzureSearchService.Search(A<string>.Ignored, A<int>.Ignored)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task BodyReturnsOk()
        {
            var controller = BuildSearchResultsController();

            A.CallTo(() => FakeAzureSearchService.Search(A<string>.Ignored, A<int>.Ignored)).Returns(
                new AzureSearchJobProfileModel
                {
                    TotalPages = 1,
                    DocumentTotal = 2,
                    Value = new List<JobProfile> { new JobProfile { Title = "test" }, },
                });

            await controller.Body("dev").ConfigureAwait(false);

            A.CallTo(() => FakeAzureSearchService.Search(A<string>.Ignored, A<int>.Ignored)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task AutoCompleteReturnsOk()
        {
            var controller = BuildSearchResultsController();

            A.CallTo(() => FakAutoCompleteService.AutoComplete(A<string>.Ignored)).Returns(new List<AutoCompleteModel>{new AutoCompleteModel{Category = "test" }, });

            var result = await controller.JobProfileSearchAuto("dev").ConfigureAwait(false);

            A.CallTo(() => FakAutoCompleteService.AutoComplete(A<string>.Ignored)).MustHaveHappenedOnceExactly();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task AutoCompleteReturnsNoContentWhenAutoCompleteReturnsNodata()
        {
            var controller = BuildSearchResultsController();

            A.CallTo(() => FakAutoCompleteService.AutoComplete(A<string>.Ignored)).Returns(new List<AutoCompleteModel>());

            var result = await controller.JobProfileSearchAuto("dev").ConfigureAwait(false);

            A.CallTo(() => FakAutoCompleteService.AutoComplete(A<string>.Ignored)).MustHaveHappenedOnceExactly();

            Assert.IsType<NoContentResult>(result);
        }
    }
}
