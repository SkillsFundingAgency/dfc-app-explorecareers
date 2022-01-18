using System;
using System.Threading.Tasks;

using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Models;

using DFC.App.ExploreCareers.Configuration;

namespace DFC.App.ExploreCareers.AzureSearch
{
    public class AzureSearchClient
    {
        private readonly SearchClient client;

        public AzureSearchClient(JobProfileSearchClientOptions searchClientOptions)
        {
            _ = searchClientOptions ?? throw new ArgumentNullException(nameof(searchClientOptions));

            // Create a client
            AzureKeyCredential credential = new AzureKeyCredential(searchClientOptions.ApiKey);
            this.client = new SearchClient(new Uri(searchClientOptions.BaseAddress), searchClientOptions.IndexName, credential);
        }

        public async Task<SearchResults<T>> SearchAsync<T>(string searchText)
        {
            var results = await client.SearchAsync<T>(searchText);

            return results.Value;
        }
    }
}
