using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DFC.App.ExploreCareers.Data.Models;
using FakeItEasy;
using Xunit;

namespace DFC.App.ExploreCareers.Services.ApiService.UnitTests.ApiExtensionTests
{
   public class ApiExtensionTests : BaseApiExtensionTests
    {
        [Fact]
        public async Task LoadDataTCallsGetAllInDataService()
        {
            var service = buildApiExtensions();

            await service.LoadDataAsync<JobCategory>().ConfigureAwait(false);

            A.CallTo(() => FakeApiDataService.GetAllAsync<JobCategory>()).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task LoadDataCallsGetAllInDataService()
        {
            var service = buildApiExtensions();

            await service.LoadDataAsync().ConfigureAwait(false);

            A.CallTo(() => FakeApiDataService.GetAllAsync()).MustHaveHappenedOnceExactly();
        }
    }
}
