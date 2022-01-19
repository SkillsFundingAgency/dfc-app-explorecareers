using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DFC.App.ExploreCareers.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class SearchResultsViewModel
    {
        public IList<JobProfileViewModel> JobProfiles { get; set; } = Array.Empty<JobProfileViewModel>();

        public int TotalPages { get; set; }

        public int PageNumber { get; set; } = 1;

        public int CurrentPage { get; set; }

        public string SearchTerm { get; set; } = string.Empty;

        public int TotalResults { get; set; }

        public bool HasNextPage => TotalPages - PageNumber > 0;

        public bool HasPreviousPage => PageNumber > 1;

        public string? NextPageUrl { get; set; }

        public string? NextPageUrlText { get; set; }

        public string? PreviousPageUrl { get; set; }

        public string? PreviousPageUrlText { get; set; }

        public string TotalResultsMessage { get; set; } = string.Empty;

        public string? DidYouMeanUrl { get; set; }

        public string DidYouMeanTerm { get; set; } = string.Empty;
    }
}
