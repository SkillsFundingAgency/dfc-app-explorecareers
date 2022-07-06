using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

using DFC.Compui.Cosmos.Contracts;

namespace DFC.App.ExploreCareers.Data.Models.ContentModels
{
    [ExcludeFromCodeCoverage]
    public class JobCategoryContentItemModel : DocumentModel
    {
        public const string DefaultPartitionKey = "/";

        public override string? PartitionKey { get; set; } = DefaultPartitionKey;

        [Required]
        public string Title { get; set; } = string.Empty;

        public string PageLocation { get; set; } = string.Empty;

        [Required]
        public string CanonicalName { get; set; } = string.Empty;
    }
}
