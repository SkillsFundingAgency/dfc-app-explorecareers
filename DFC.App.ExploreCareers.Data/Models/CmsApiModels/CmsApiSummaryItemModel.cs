using System;

using DFC.Content.Pkg.Netcore.Data.Contracts;

using Newtonsoft.Json;

namespace DFC.App.ExploreCareers.Data.Models.CmsApiModels
{
    public class CmsApiSummaryItemModel : IApiDataModel
    {
        [JsonProperty(PropertyName = "uri")]
        public Uri? Url { get; set; }

        [JsonProperty(PropertyName = "skos__prefLabel")]
        public string? Title { get; set; }

        public DateTime? CreatedDate { get; set; }

        [JsonProperty(PropertyName = "ModifiedDate")]
        public DateTime Published { get; set; }
    }
}
