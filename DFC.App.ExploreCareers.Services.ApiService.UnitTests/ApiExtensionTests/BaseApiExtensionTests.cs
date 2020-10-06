using DFC.App.ExploreCareers.ApiService;
using DFC.App.ExploreCareers.ApiService.Extensions;
using DFC.App.ExploreCareers.Data.Models;
using FakeItEasy;

namespace DFC.App.ExploreCareers.Services.ApiService.UnitTests.ApiExtensionTests
{
    public abstract class BaseApiExtensionTests
    {
        protected BaseApiExtensionTests()
        {
            FakeApiDataService = A.Fake<IApiDataService<JobCategoryApiClientOptions>>();
        }

        protected IApiDataService<JobCategoryApiClientOptions> FakeApiDataService { get; }

        protected ApiExtensions buildApiExtensions()
        {
            return new ApiExtensions(FakeApiDataService);
        }
    }
}
