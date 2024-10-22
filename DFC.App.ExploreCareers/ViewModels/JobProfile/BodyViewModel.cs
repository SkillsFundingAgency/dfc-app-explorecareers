using System.Collections.Generic;

namespace DFC.App.ExploreCareers.ViewModels.JobProfile
{
    public class BodyViewModel
    {
        public IList<JobProfile> JobProfile { get; set; } = new List<JobProfile>();

        public List<SharedContent>? SharedContents { get; set; }

        public string sectorlandingContentItemId { get; set; }

        public string jobSector { get; set; }

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
