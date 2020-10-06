using DFC.App.ExploreCareers.Data.Models;
using Newtonsoft.Json;
using Polly.CircuitBreaker;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.ApiService
{
    public class ApiDataService<TClientOptions> : IApiDataService<TClientOptions>
        where TClientOptions : JobCategoryApiClientOptions
    {
        private readonly HttpClient httpClient;
        private readonly TClientOptions clientOptions;

        public ApiDataService(HttpClient httpClient, TClientOptions clientOptions)
        {
            this.httpClient = httpClient;
            this.clientOptions = clientOptions;
        }

        public async Task<T> GetAllAsync<T>()
            where T : class
        {
            var result = await GetAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<T>(result);
        }

        public async Task<string> GetAllAsync()
        {
            return await GetAsync().ConfigureAwait(false);
        }

        private async Task<string> GetAsync()
        {
            var url = $"{clientOptions.BaseAddress}";

            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(MediaTypeNames.Text.Html));

            try
            {
                var response = await httpClient.SendAsync(request).ConfigureAwait(false);
                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    responseString = string.Empty;
                }

                return responseString;
            }
            catch (BrokenCircuitException)
            {
                return string.Empty;
            }
        }
    }
}
