using System.Collections.Generic;
using DFC.App.ExploreCareers.ViewModels.JobCategories;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace DFC.App.ExploreCareers.ViewModels.SectorLandingPage
{
    public class SectorLandingPageResponse
    {
        [JsonProperty("sectorLandingPage")]
        public List<SectorLandingPage> SectorLandingPage { get; set; }
    }

    public class SectorLandingPage
    {
        [JsonProperty("contentItemId")]
        public string ContentItemId { get; set; }

        [JsonProperty("graphSync")]
        public GraphSync GraphSync { get; set; }

        [JsonProperty("render")]
        public string Render { get; set; }

        [JsonProperty("heroBanner")]
        public HeroBanner HeroBanner { get; set; }

        [JsonProperty("aboutThisSector")]
        public string AboutThisSector { get; set; }

        [JsonProperty("description")]
        public Description Description { get; set; }

        [JsonProperty("pageLocation")]
        public PageLocation PageLocation { get; set; }
    }

    public class GraphSync
    {
        [JsonProperty("nodeId")]
        public string NodeId { get; set; }
    }

    public class HeroBanner
    {
        [JsonProperty("html")]
        public string Html { get; set; }
    }

    public class Description
    {
        [JsonProperty("html")]
        public string Html { get; set; }
    }

    public class PageLocation
    {
        [JsonProperty("fullUrl")]
        public string FullUrl { get; set; }
    }
}
