using System.Collections.Generic;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.Models;

namespace DFC.App.ExploreCareers.AzureSearch
{
    public interface IAzureSearchService
    {
        Task<List<AutoCompleteModel>> AutoComplete(string searchTerm);

        Task<AzureSearchJobProfileModel> Search(string searchTerm, int skip = 1);
    }
}