namespace DFC.App.ExploreCareers.ViewModels.SectorLandingPage
{

    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SectorLandingPageResponse
    {
        [JsonProperty("sectorLandingPage")]
        public List<SectorLandingPage> SectorLandingPage { get; set; }
    }

    public class SectorLandingPage
    {
        [JsonProperty("contentItemId")]
        public string ContentItemId { get; set; }

        [JsonProperty("displayText")]
        public string DisplayText { get; set; }

        [JsonProperty("heroBanner")]
        public HtmlContent HeroBanner { get; set; }

        [JsonProperty("description")]
        public HtmlContent Description { get; set; }

        [JsonProperty("videoImage")]
        public VideoImage VideoImage { get; set; }

        [JsonProperty("videoDuration")]
        public string VideoDuration { get; set; }

        [JsonProperty("videoTranscript")]
        public string VideoTranscript { get; set; }

        [JsonProperty("profileDescription")]
        public HtmlContent ProfileDescription { get; set; }

        [JsonProperty("jobProfile")]
        public JobProfile JobProfile { get; set; }

        [JsonProperty("jobDescription")]
        public HtmlContent JobDescription { get; set; }

        [JsonProperty("furtherInspiration")]
        public HtmlContent FurtherInspiration { get; set; }

        [JsonProperty("jobProfileInspiration")]
        public JobProfileInspiration JobProfileInspiration { get; set; } 

        [JsonProperty("jobProfileInspirationDescription")]
        public HtmlContent JobProfileInspirationDescription { get; set; }

        [JsonProperty("realStoryDescription")]
        public HtmlContent RealStoryDescription { get; set; }

        [JsonProperty("realStoryImage")]
        //public HtmlContent RealStoryImage { get; set; }
        public RealStoryImage RealStoryImage { get; set; }

        [JsonProperty("realStoryImageDescription")]
        public HtmlContent RealStoryImageDescription { get; set; }

        [JsonProperty("exploreAllSectors")]
        public HtmlContent ExploreAllSectors { get; set; }
    }

    public class HtmlContent
    {
        [JsonProperty("html")]
        public string Html { get; set; }
    }

    public class VideoImage
    {
        [JsonProperty("paths")]
        public List<string> Paths { get; set; }

        [JsonProperty("urls")]
        public List<string> Urls { get; set; }
    }

    public class RealStoryImage
    {
        [JsonProperty("paths")]
        public List<string> Paths { get; set; } = new List<string>();

        [JsonProperty("urls")]
        public List<string> Urls { get; set; } = new List<string>();

        [JsonProperty("mediaText")]
        public List<string> MediaText { get; set; } = new List<string>();
    }

    public class JobProfile
    {
        [JsonProperty("contentItems")]
        public List<JobProfileItem> ContentItems { get; set; }
    }

    public class JobProfileItem
    {
        [JsonProperty("displayText")]
        public string DisplayText { get; set; }

        [JsonProperty("modifiedUtc")]
        public DateTime ModifiedUtc { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("salarystarterperyear")]
        public int SalaryStarterPerYear { get; set; }

        [JsonProperty("salaryexperiencedperyear")]
        public int SalaryExperiencedPerYear { get; set; }

        [JsonProperty("pageLocation")]
        public PageLocation PageLocation { get; set; }
    }

    public class JobProfileInspiration
    {
        [JsonProperty("contentItems")]
        public List<JobProfileInspirationItem> ContentItems { get; set; }
    }

    public class JobProfileInspirationItem
    {
        [JsonProperty("displayText")]
        public string DisplayText { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("salarystarterperyear")]
        public int SalaryStarterPerYear { get; set; }

        [JsonProperty("salaryexperiencedperyear")]
        public int SalaryExperiencedPerYear { get; set; }

        [JsonProperty("pageLocation")]
        public PageLocation PageLocation { get; set; }
    }

    public class PageLocation
    {
        [JsonProperty("fullUrl")]
        public string FullUrl { get; set; }
    }

}
