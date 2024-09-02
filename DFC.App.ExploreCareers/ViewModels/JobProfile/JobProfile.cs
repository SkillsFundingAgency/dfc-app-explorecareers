using System.Collections.Generic;
using Newtonsoft.Json;

namespace DFC.App.ExploreCareers.ViewModels.JobProfile
{
    public class JobProfileSectorResponse
    {
        [JsonProperty("jobProfile")]
        public List<JobProfile> JobProfileSector { get; set; } = new List<JobProfile>();
    }

    public class JobProfile
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

        [JsonProperty("render")]
        public string Render { get; set; }

        //[JsonProperty("sectorLandingPage")]
        //public SectorLandingPage SectorLandingPage { get; set; }

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
}
