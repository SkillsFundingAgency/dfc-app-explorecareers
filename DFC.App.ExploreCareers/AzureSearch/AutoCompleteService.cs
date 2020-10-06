using DFC.App.ExploreCareers.Models.AzureSearch;
using Newtonsoft.Json;
using Polly.CircuitBreaker;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.AzureSearch
{
    public class AutoCompleteService<TClientOptions> :IAutoCompleteService<TClientOptions>
    where TClientOptions : JobCategorySearchClientOptions
    {
        private const string AutocompleteTerms =
            "searchautocomplete?maxNumberDisplayed=5&fuzzySearch=True";

        private readonly HttpClient httpClient;
        private readonly TClientOptions clientOptions;

        public AutoCompleteService(HttpClient httpClient, TClientOptions clientOptions)
        {
            this.httpClient = httpClient;
            this.clientOptions = clientOptions;
        }

        public async Task<List<AutoCompleteModel>> AutoComplete(string searchTerm)
        {
            var url = $"{clientOptions.BaseAddress}{AutocompleteTerms}&term={searchTerm}";

            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));

            var data = new List<AutoCompleteModel>();

            try
            {
                var response = await httpClient.SendAsync(request).ConfigureAwait(false);
                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                return !response.IsSuccessStatusCode ? data : JsonConvert.DeserializeObject<List<AutoCompleteModel>>(responseString);
            }
            catch (BrokenCircuitException)
            {
                return data;
            }
        }
    }
}
