using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DFC.App.ExploreCareers.ViewModels.JobProfile.SectorLandingPage
{
    public class SectorLandingPageResponse
    {
        [JsonProperty("sectorLandingPage")]
        public List<SectorLandingPage> SectorLandingPage { get; set; } = new List<SectorLandingPage>();
    }

    public class SectorLandingPage
    {
        [JsonProperty("displayText")]
        public string DisplayText { get; set; }

        [JsonProperty("jobProfile")]
        public JobProfile? JobProfile { get; set; }
    }

    public class JobProfile
    {
        [JsonProperty("contentItems")]
        public List<JobProfileContentItem> ContentItems { get; set; } = new List<JobProfileContentItem>();
    }

    public class JobProfileContentItem
    {
        [JsonProperty("displayText")]
        public string DisplayText { get; set; }

        [JsonProperty("contentItemId")]
        public string ContentItemId { get; set; } = string.Empty;
    }

}
