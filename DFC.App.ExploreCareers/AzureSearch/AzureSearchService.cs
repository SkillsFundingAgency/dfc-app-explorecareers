using DFC.App.ExploreCareers.Models.AzureSearch;
using Newtonsoft.Json;
using Polly.CircuitBreaker;
using System;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.AzureSearch
{
    public class AzureSearchService<TClientOptions> : IAzureSearchService<TClientOptions>
        where TClientOptions : JobProfileSearchClientOptions
    {
        private readonly HttpClient httpClient;
        private readonly TClientOptions clientOptions;

        public AzureSearchService(HttpClient httpClient, TClientOptions clientOptions)
        {
            this.clientOptions = clientOptions;
            this.httpClient = httpClient;
        }

        public async Task<AzureSearchJobProfileModel> Search(string searchTerm, int skip = 1)
        {
            var skipValue = clientOptions.PageSize * (skip - 1);
            var url = $"{clientOptions.BaseAddress}?api-version=2020-06-30&search={searchTerm}&$count=true&$top={clientOptions.PageSize}&$skip={skipValue}";

            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
            request.Headers.Add("api-key", clientOptions.ApiKey);

            try
            {
                var response = await httpClient.SendAsync(request).ConfigureAwait(false);
                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var responseData = JsonConvert.DeserializeObject<AzureSearchJobProfileModel>(responseString);
                responseData.TotalPages = Math.Ceiling((double)responseData.DocumentTotal / clientOptions.PageSize);
                return responseData;

            }
            catch (BrokenCircuitException)
            {
                return null;
            }
        }
    }
}
