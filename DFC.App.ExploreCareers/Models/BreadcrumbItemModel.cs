using System.Diagnostics.CodeAnalysis;

namespace DFC.App.ExploreCareers.Models
{
    [ExcludeFromCodeCoverage]
    public class BreadcrumbItemModel
    {
        public string? Route { get; set; }

        public string? Title { get; set; }

        public string? AlternativeTitle { get; set; }
    }
}
