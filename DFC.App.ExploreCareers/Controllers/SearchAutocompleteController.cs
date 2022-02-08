using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.AzureSearch;
using DFC.App.ExploreCareers.Models;

using Microsoft.AspNetCore.Mvc;

namespace DFC.App.ExploreCareers.Controllers
{
    [Route("searchautocomplete")]
    public class SearchAutocompleteController : BaseController
    {
        private const int MaxResultsDisplayed = 5;
        private const bool UseFuzzySearch = true;

        private readonly IAzureSearchService azureSearchService;

        public SearchAutocompleteController(IAzureSearchService azureSearchService)
        {
            this.azureSearchService = azureSearchService;
        }

        [HttpGet]
        [Route("head")]
        public IActionResult Head()
        {
            return NoContent();
        }

        [HttpGet]
        public async Task<IEnumerable<AutoCompleteModel>> Get(string? term = "")
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return Array.Empty<AutoCompleteModel>();
            }

            var results = await azureSearchService.GetSuggestionsAsync(term, MaxResultsDisplayed, UseFuzzySearch);

            return results;
        }
    }
}
