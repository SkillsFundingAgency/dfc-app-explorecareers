using System.Collections.Generic;
using Newtonsoft.Json;

namespace DFC.App.ExploreCareers.ViewModels.JobProfileSector
{
    public class JobProfileSectorResponse
    {
        [JsonProperty("jobProfileSector")]
        public List<JobProfileSector> JobProfileSector { get; set; }
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

        [JsonProperty("render")]
        public string Render { get; set; }

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

    public class Content
    {
        [JsonProperty("html")]
        public string Html { get; set; }
    }
}
