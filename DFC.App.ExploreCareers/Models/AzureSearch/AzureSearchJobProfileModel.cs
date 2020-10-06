using System.Collections.Generic;
using Newtonsoft.Json;

namespace DFC.App.ExploreCareers.Models.AzureSearch
{
    public class AzureSearchJobProfileModel
    {
        public List<JobProfile> Value { get; set; } = new List<JobProfile>();

        [JsonProperty("@odata.count")]
        public int DocumentTotal { get; set; }

        [JsonIgnore]
        public double TotalPages { get; set; } = 1;
    }
}
