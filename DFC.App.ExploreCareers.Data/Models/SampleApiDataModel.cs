using DFC.App.ExploreCareers.Data.Contracts;
using System;
using System.Collections.Generic;

namespace DFC.App.ExploreCareers.Data.Models
{
    public class SampleApiDataModel : IApiDataModel
    {
        public Guid? ItemId { get; set; }

        public string? CanonicalName { get; set; }

        public Guid? Version { get; set; }

        public string? BreadcrumbTitle { get; set; }

        public bool IncludeInSitemap { get; set; }

        public Uri? Url { get; set; }

        public IList<string>? AlternativeNames { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Keywords { get; set; }

        public IList<Uri>? ContentItemUrls { get; set; }

        public IList<SampleApiContentItemModel> ContentItems { get; set; } = new List<SampleApiContentItemModel>();

        public DateTime? Published { get; set; }
    }
}
