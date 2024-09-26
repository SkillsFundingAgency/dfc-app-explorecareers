using Newtonsoft.Json;
using System.Collections.Generic;

namespace DFC.App.ExploreCareers.ViewModels.AllCareersJobProfile
{

    public class AllJobProfileResponse
    {
        [JsonProperty("jobProfile")]
        public List<AllCareersJobProfile> JobProfile { get; set; }
    }

    public class AllCareersJobProfile
    {
        [JsonProperty("contentItemId")]
        public string ContentItemId { get; set; }

        [JsonProperty("displayText")]
        public string DisplayText { get; set; }

        [JsonProperty("alternativeTitle")]
        public string AlternativeTitle { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("salarystarterperyear")]
        public decimal? SalaryStarterPerYear { get; set; } // Nullable

        [JsonProperty("salaryexperiencedperyear")]
        public decimal? SalaryExperiencedPerYear { get; set; } // Nullable

        [JsonProperty("pageLocation")]
        public PageLocation PageLocation { get; set; }

        [JsonProperty("jobProfileCategory")]
        public JobProfileCategory JobProfileCategory { get; set; }
    }

    public class JobProfileCategory
    {
        [JsonProperty("contentItems")]
        public List<JobProfileCategoryContentItem> ContentItems { get; set; }
    }

    public class JobProfileCategoryResponse
    {
        [JsonProperty("jobProfileCategory")]
        public List<JobProfileCategoryContentItem> JobProfileCategories { get; set; }
    }

    public class JobProfileCategoryContentItem
    {
        [JsonProperty("contentItemId")]
        public string ContentItemId { get; set; }

        [JsonProperty("displayText")]
        public string DisplayText { get; set; }
    }


    public class PageLocation
    {
        [JsonProperty("fullUrl")]
        public string FullUrl { get; set; } = string.Empty;

        [JsonProperty("urlName")]
        public string UrlName { get; set; } = string.Empty;
    }

}
