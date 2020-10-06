using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.ApiService.Extensions
{
    public interface IApiExtensions
    {
        Task<T> LoadDataAsync<T>()
            where T : class;

        Task<string> LoadDataAsync();
    }
}
