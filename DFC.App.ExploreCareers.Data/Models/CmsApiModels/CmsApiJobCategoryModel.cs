using System.Diagnostics.CodeAnalysis;

using DFC.Content.Pkg.Netcore.Data.Models;

using Newtonsoft.Json;

namespace DFC.App.ExploreCareers.Data.Models.CmsApiModels
{
    [ExcludeFromCodeCoverage]
    public class CmsApiJobCategoryModel : BaseContentItemModel
    {
        [JsonProperty("pagelocation_UrlName")]
        public string CanonicalName { get; set; } = string.Empty;

        [JsonProperty("pagelocation_FullUrl")]
        public string PageLocation { get; set; } = string.Empty;
    }
}
