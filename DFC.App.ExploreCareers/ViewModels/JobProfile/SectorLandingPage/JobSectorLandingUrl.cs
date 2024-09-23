using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace DFC.App.ExploreCareers.ViewModels.JobProfile.SectorLandingPage
{

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class PageLocation
    {
        [JsonProperty("fullUrl")]
        public string FullUrl { get; set; } = string.Empty;

        [JsonProperty("urlName")]
        public string UrlName { get; set; } = string.Empty;
    }

    public class SectorLandingPageContentItem
    {
        [JsonProperty("contentItemId")]
        public string ContentItemId { get; set; } = string.Empty;

        [JsonProperty("displayText")]
        public string DisplayText { get; set; } = string.Empty;

        [JsonProperty("modifiedUtc")]
        public DateTime? ModifiedUtc { get; set; }

        [JsonProperty("pageLocation")]
        public PageLocation PageLocation { get; set; }
    }

    public class SectorLandingPageUrl
    {
        [JsonProperty("contentItems")]
        public List<SectorLandingPageContentItem> ContentItems { get; set; }
    }

    public class JobSectorLandingUrl
    {
        [JsonProperty("contentItemId")]
        public string ContentItemId { get; set; } = string.Empty;

        [JsonProperty("displayText")]
        public string DisplayText { get; set; } = string.Empty;

        [JsonProperty("sectorLandingPage")]
        public SectorLandingPageUrl SectorLandingPage { get; set; }
    }

    public class JobProfileSectorResponse
    {
        [JsonProperty("jobProfileSector")]
        public List<JobSectorLandingUrl> JobProfileSector { get; set; }
    }
}
