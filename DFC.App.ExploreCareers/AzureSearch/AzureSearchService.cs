using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Azure.Search.Documents;

using DFC.App.ExploreCareers.Models;

namespace DFC.App.ExploreCareers.AzureSearch
{
    public class AzureSearchService : IAzureSearchService
    {
        private readonly SearchClient azureSearchClient;

        public AzureSearchService(SearchClient client)
        {
            this.azureSearchClient = client;
        }

        public async Task<AzureSearchJobProfileModel> Search(string searchTerm, int skip = 1)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<AutoCompleteModel>> AutoComplete(string searchTerm)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<JobProfileIndex>> GetProfilesByCategoryAsync(string category)
        {
            var searchOptions = new SearchOptions
            {
                Size = 500,
                Filter = $"{nameof(JobProfileIndex.JobProfileCategoryUrls)}/any(c: c eq '{category}')",
                OrderBy = { nameof(JobProfileIndex.Title) },
                Select = { nameof(JobProfileIndex.Title), nameof(JobProfileIndex.AlternativeTitle), nameof(JobProfileIndex.UrlName), nameof(JobProfileIndex.Overview) }
            };

            var searchResult = await azureSearchClient.SearchAsync<JobProfileIndex>("*", searchOptions);
            var results = new List<JobProfileIndex>();
            await foreach (var result in searchResult.Value.GetResultsAsync())
            {
                results.Add(result.Document);
            }

            return results.OrderBy(p => p.Title).ToList();
        }
    }
}
