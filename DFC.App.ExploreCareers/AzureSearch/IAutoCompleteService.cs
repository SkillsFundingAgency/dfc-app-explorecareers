using DFC.App.ExploreCareers.Models.AzureSearch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.AzureSearch
{
    public interface IAutoCompleteService<TClientOptions>
        where TClientOptions : JobCategorySearchClientOptions
    {
        Task<List<AutoCompleteModel>> AutoComplete(string searchTerm);

    }
}
