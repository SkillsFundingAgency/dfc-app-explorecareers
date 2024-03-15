using System.Collections.Generic;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.Models;

namespace DFC.App.ExploreCareers.AzureSearch
{
    public interface IAzureSearchService
    {
        Task<IEnumerable<AutoCompleteModel>> GetSuggestionsFromSearchAsync(string searchTerm, int maxResultCount = 5);

        Task<AzureSearchJobProfileModel> SearchAsync(string searchTerm, int pageNumber = 1);
    }
}