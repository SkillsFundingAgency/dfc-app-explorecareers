using Newtonsoft.Json;
using System.Collections.Generic;

namespace DFC.App.ExploreCareers.ViewModels.JobProfile
{
    public class JobProfileResponse
    {
        [JsonProperty("jobProfile")]
        public List<JobProfile> JobProfiles { get; set; }
    }

    public class JobProfile
    {
        [JsonProperty("jobSectorTitle")]
        public string JobSectorTitle { get; set; } = string.Empty;

        [JsonProperty("displayText")]
        public string DisplayText { get; set; }

        [JsonProperty("alternativeTitle")]
        public string AlternativeTitle { get; set; }

        [JsonProperty("contentItemId")]
        public string ContentItemId { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("salarystarterperyear")]
        public int SalaryStarterPerYear { get; set; }

        [JsonProperty("salaryexperiencedperyear")]
        public int SalaryExperiencedPerYear { get; set; }

        [JsonProperty("pageLocation")]
        public PageLocation PageLocation { get; set; }

        [JsonProperty("jobProfileSector")]
        public JobProfileSector JobProfileSector { get; set; }
    }

    public class JobProfileSector
    {
        [JsonProperty("contentItems")]
        public List<JobProfileSectorContentItem> ContentItems { get; set; }
    }

    public class JobProfileSectorContentItem
    {
        [JsonProperty("displayText")]
        public string DisplayText { get; set; } = string.Empty;

        [JsonProperty("fullUrl")]
        public string FullUrl { get; set; } = string.Empty;

        [JsonProperty("urlName")]
        public string UrlName { get; set; } = string.Empty;
    }

    public class PageLocation
    {
        [JsonProperty("fullUrl")]
        public string FullUrl { get; set; } = string.Empty;

        [JsonProperty("urlName")]
        public string UrlName { get; set; } = string.Empty;
    }
}
