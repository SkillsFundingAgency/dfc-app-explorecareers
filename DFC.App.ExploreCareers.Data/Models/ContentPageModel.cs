using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DFC.App.ExploreCareers.Data.Models
{
    public class ContentPageModel : DFC.Compui.Cosmos.Models.ContentPageModel
    {
        [Required]
        [JsonProperty(Order = -10)]
        public string? PartitionKey => "jobcategory";

        public override string? PageLocation { get; set; }

        public new string? Content { get; set; }

        public IList<ContentItemModel>? ContentItems { get; set; }
    }
}
