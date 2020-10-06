using DFC.App.ExploreCareers.Data.Models;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.ApiService
{
    public interface IApiDataService<TClientOptions>
        where TClientOptions : JobCategoryApiClientOptions
    {
        Task<T> GetAllAsync<T>()
            where T : class;

        Task<string> GetAllAsync();
    }
}
