using System.Collections.Generic;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.Models;

namespace DFC.App.ExploreCareers.AzureSearch
{
    public interface IAzureSearchService
    {
        Task<IEnumerable<AutoCompleteModel>> GetSuggestionsAsync(string searchTerm, int maxResultCount = 5, bool useFuzzyMatching = true);

        Task<AzureSearchJobProfileModel> SearchAsync(string searchTerm, int pageNumber = 1);

        Task<List<JobProfileIndex>> GetProfilesByCategoryAsync(string category);
    }
}