using DFC.App.ExploreCareers.Models.AzureSearch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.AzureSearch
{
    public interface IAzureSearchService<TClientOptions>
        where TClientOptions : JobProfileSearchClientOptions
    {
        Task<AzureSearchJobProfileModel> Search(string searchTerm, int page = 1);
    }
}
