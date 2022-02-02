using System.Collections.Generic;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.Models;

namespace DFC.App.ExploreCareers.AzureSearch
{
    public interface IAzureSearchService
    {
        Task<List<AutoCompleteModel>> AutoComplete(string searchTerm);

        Task<AzureSearchJobProfileModel> SearchAsync(string searchTerm, int pageNumber = 1);

        Task<List<JobProfileIndex>> GetProfilesByCategoryAsync(string category);
    }
}