using DFC.App.ExploreCareers.Data.Models;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.ApiService.Extensions
{
    public class ApiExtensions : IApiExtensions
    {
        private readonly IApiDataService<JobCategoryApiClientOptions> apiDataService;

        public ApiExtensions(IApiDataService<JobCategoryApiClientOptions> apiDataService)
        {
            this.apiDataService = apiDataService;
        }

        public async Task<T> LoadDataAsync<T>()
           where T : class
        {
            var data = await apiDataService.GetAllAsync<T>().ConfigureAwait(false);
            return data;
        }

        public async Task<string> LoadDataAsync()
        {
            var data = await apiDataService.GetAllAsync().ConfigureAwait(false);
            return data;
        }
    }
}
