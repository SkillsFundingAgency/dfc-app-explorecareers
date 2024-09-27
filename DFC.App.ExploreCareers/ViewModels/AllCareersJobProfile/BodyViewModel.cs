using System.Collections.Generic;

namespace DFC.App.ExploreCareers.ViewModels.AllCareersJobProfile
{
    public class BodyViewModel
    {
        public IList<AllCareersJobProfile> JobProfile { get; set; } = new List<AllCareersJobProfile>();

        public List<JobProfileCategoryContentItem> CategoryContentItems { get; set; } = new List<JobProfileCategoryContentItem>();

        //public IList<JobProfileCategoryContentItem> JobProfileCategories { get; set; } = new List<JobProfileCategoryContentItem>();

        public List<string> selectedCategoryIds = new List<string>();

        public int TotalPages { get; set; }

        public int PageSize { get; set; } = 20;

        public int PageNumber { get; set; } = 1;

        public int TotalResults { get; set; }

        public bool HasNextPage => TotalPages - PageNumber > 0;

        public bool HasPreviousPage => PageNumber > 1;

        public string? NextPageUrl { get; set; }

        public string? NextPageUrlText { get; set; }

        public string? PreviousPageUrl { get; set; }

        public string? PreviousPageUrlText { get; set; }
    }
}
