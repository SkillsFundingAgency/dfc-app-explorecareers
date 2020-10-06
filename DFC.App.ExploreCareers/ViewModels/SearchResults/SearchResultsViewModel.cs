using DFC.App.ExploreCareers.Models.AzureSearch;
using System.Collections.Generic;

namespace DFC.App.ExploreCareers.ViewModels.SearchResults
{
    public class SearchResultsViewModel
    {
        public IList<JobProfile> JobProfiles { get; set; }

        public double TotalPages { get; set; }

        public int CurrentPage { get; set; }

        public string SearchTerm { get; set; }

        public int TotalResults { get; set; }
    }
}
