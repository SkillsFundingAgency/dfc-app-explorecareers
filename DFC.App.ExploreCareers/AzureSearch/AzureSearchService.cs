using System.Collections.Generic;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.Models;

namespace DFC.App.ExploreCareers.AzureSearch
{
    public class AzureSearchService : IAzureSearchService
    {
        public AzureSearchService()
        {
        }

        public async Task<AzureSearchJobProfileModel> Search(string searchTerm, int skip = 1)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<AutoCompleteModel>> AutoComplete(string searchTerm)
        {
            throw new System.NotImplementedException();
        }
    }
}
