using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Azure.Search.Documents;
using Azure.Search.Documents.Models;

using DFC.App.ExploreCareers.Models;

namespace DFC.App.ExploreCareers.AzureSearch
{
    public class AzureSearchService : IAzureSearchService
    {
        public static readonly string DefaultSuggester = "sg";
        public static readonly string ScoringProfile = "jp";

        private readonly SearchClient azureSearchClient;

        public AzureSearchService(SearchClient client)
        {
            azureSearchClient = client;
        }

        public async Task<IEnumerable<AutoCompleteModel>> GetSuggestionsAsync(string searchTerm, int maxResultCount = 5, bool useFuzzyMatching = true)
        {
            SuggestOptions options = new SuggestOptions
            {
                Size = maxResultCount,
                UseFuzzyMatching = useFuzzyMatching,
                Select = { nameof(JobProfileIndex.Title) }
            };
            var searchResult = await azureSearchClient.SuggestAsync<JobProfileIndex>(searchTerm, DefaultSuggester, options);
            return searchResult?.Value?.Results?.Select(r => new AutoCompleteModel { Label = r.Text }) ?? Array.Empty<AutoCompleteModel>();
        }

        public async Task<IEnumerable<AutoCompleteModel>> GetSuggestionsFromSearchAsync(string searchTerm, int maxResultCount = 5)
        {
            var options = new SearchOptions
            {
                Size = maxResultCount,
                ScoringProfile = ScoringProfile,
                QueryType = SearchQueryType.Full,
                Select = { nameof(JobProfileIndex.Title), 
                           nameof(JobProfileIndex.AlternativeTitle),

                }
            };

            var cleanedSearchTerm = SearchBuilder.RemoveSpecialCharactersFromTheSearchTerm(searchTerm);
            var trimmedSearchTerm = SearchBuilder.TrimCommonWordsAndSuffixes(cleanedSearchTerm);
            var partialTermToSearch = SearchBuilder.BuildContainPartialSearch(trimmedSearchTerm);
            var finalComputedSearchTerm = SearchBuilder.BuildSearchExpression(searchTerm, cleanedSearchTerm, partialTermToSearch);

            var searchResult = await azureSearchClient.SearchAsync<JobProfileIndex>(finalComputedSearchTerm, options);
            var jobProfiles = searchResult.Value.GetResults()
                .Select((r, idx) =>
                {
                    var doc = r.Document;
                    doc.Rank = idx + 1;
                    return r.Document;
                });
            var listTitles = Reorder(jobProfiles, searchTerm, 1).ToList();
            var listResult = new List<AutoCompleteModel>();

            foreach (var item in listTitles)
            {
                var result = new AutoCompleteModel();
                if (item.AlternativeTitle.Count() > 0 && item.Title != item.AlternativeTitle.FirstOrDefault())
                {
                    result.Label = item.Title + " (" + item.AlternativeTitle.FirstOrDefault() + ")";
                }
                else
                {
                    result.Label = item.Title;
                }

                listResult.Add(result);
            }

            return listResult.Count() > 0 ? listResult.Select(r => new AutoCompleteModel { Label = r.Label }) : Array.Empty<AutoCompleteModel>();
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

        public async Task<AzureSearchJobProfileModel> SearchAsync(string searchTerm, int pageNumber = 1)
        {
            var skip = pageNumber < 1 ? 0 : ((pageNumber - 1) * SearchConfig.PageSize);
            var searchOptions = new SearchOptions
            {
                ScoringProfile = ScoringProfile,
                IncludeTotalCount = true,
                QueryType = SearchQueryType.Full,
                Size = SearchConfig.PageSize,
                Skip = skip,
                Select =
                {
                    nameof(JobProfileIndex.Title),
                    nameof(JobProfileIndex.AlternativeTitle),
                    nameof(JobProfileIndex.UrlName),
                    nameof(JobProfileIndex.Overview),
                    nameof(JobProfileIndex.SalaryStarter),
                    nameof(JobProfileIndex.SalaryExperienced),
                    nameof(JobProfileIndex.JobProfileCategoriesWithUrl)
                }
            };

            var cleanedSearchTerm = SearchBuilder.RemoveSpecialCharactersFromTheSearchTerm(searchTerm);
            var trimmedSearchTerm = SearchBuilder.TrimCommonWordsAndSuffixes(cleanedSearchTerm);
            var partialTermToSearch = SearchBuilder.BuildContainPartialSearch(trimmedSearchTerm);
            var finalComputedSearchTerm = SearchBuilder.BuildSearchExpression(searchTerm, cleanedSearchTerm, partialTermToSearch);

            var response = await azureSearchClient.SearchAsync<JobProfileIndex>(finalComputedSearchTerm, searchOptions);

            var jobProfiles = response.Value.GetResults()
                .Select((r, idx) =>
                {
                    var doc = r.Document;
                    doc.Rank = idx + 1;
                    return r.Document;
                });

            return new AzureSearchJobProfileModel
            {
                TotalResults = (int?)response.Value.TotalCount ?? 0,
                JobProfiles = Reorder(jobProfiles, searchTerm, pageNumber)
            };
        }

        private static IEnumerable<JobProfileIndex> Reorder(IEnumerable<JobProfileIndex> jobProfiles, string searchTerm, int pageNumber)
        {
            if (pageNumber is 1 && jobProfiles.Any())
            {
                var profiles = jobProfiles.ToList();
                var searchedProfile = profiles.FirstOrDefault(p => p.Title?.Equals(searchTerm, StringComparison.OrdinalIgnoreCase) is true
                   || p.AlternativeTitle?.Any(a => a.Equals(searchTerm, StringComparison.OrdinalIgnoreCase)) is true);

                // The results contain a profile and its not at the top.
                if (searchedProfile != null && searchedProfile.Rank != 1)
                {
                    searchedProfile.Rank = 0;
                }

                return profiles.OrderBy(r => r.Rank);
            }

            return jobProfiles;
        }
    }
}
