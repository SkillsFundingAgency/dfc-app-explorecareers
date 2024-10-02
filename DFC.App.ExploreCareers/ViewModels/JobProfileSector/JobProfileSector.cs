﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace DFC.App.ExploreCareers.ViewModels.JobProfileSector
{
    public class JobProfileSectorResponse
    {
        [JsonProperty("jobProfileSector")]
        public List<JobProfileSector> JobProfileSector { get; set; } = new List<JobProfileSector>();
    }

    public class JobProfileSector
    {
        /// <summary>
        /// Gets or sets the Job profile sector DisplayText.
        /// </summary>
        /// <value>
        /// The Banner HTML.
        /// </value>
        [JsonProperty("contentItemId")]
        public string ContentItemId { get; set; }

        [JsonProperty("graphSync")]
        public GraphSync GraphSync { get; set; }

        [JsonProperty("displayText")]
        public string DisplayText { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("render")]
        public string Render { get; set; }

        [JsonProperty("sectorLandingPage")]
        public SectorLandingPage? SectorLandingPage { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("sectorLandingPages")]
        public List<ViewModels.SectorLandingPage.SectorLandingPage>? SectorLandingPageSearchResults { get; set; } = new List<ViewModels.SectorLandingPage.SectorLandingPage>();

        //[JsonProperty("isActive")]
        //public bool IsActive { get; set; }

        //[JsonProperty("isGlobal")]
        //public bool IsGlobal { get; set; }

        //[JsonProperty("content")]
        //public Content Content { get; set; }
    }

    public class GraphSync
    {
        [JsonProperty("nodeId")]
        public string NodeId { get; set; }
    }

    public class SectorLandingPage
    {
        // Represents the list of content items within the sector landing page
        [JsonProperty("contentItems")]
        public List<ContentItem>? ContentItems { get; set; } = new List<ContentItem>();
    }

    public class ContentItem
    {
        [JsonProperty("contentItemId")]
        public string ContentItemId { get; set; } = string.Empty;

        [JsonProperty("displayText")]
        public string DisplayText { get; set; }

        [JsonProperty("pageLocation")]
        public PageLocation PageLocation { get; set; }
    }

    public class Content
    {
        [JsonProperty("html")]
        public string Html { get; set; }
    }

    public class PageLocation
    {
        [JsonProperty("fullUrl")]
        public string FullUrl { get; set; }

        [JsonProperty("urlName")]
        public string UrlName { get; set; } = string.Empty;
    }

    public class Image
    {
        [JsonProperty("Urls")]
        public List<string> Urls { get; set; } 
    }


}
