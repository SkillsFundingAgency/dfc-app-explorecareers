using System.Diagnostics.CodeAnalysis;

namespace DFC.App.ExploreCareers.ViewModels.JobCategories
{
    [ExcludeFromCodeCoverage]
    public class JobProfileByCategoryViewModel
    {
        public string? Title { get; set; }

        public string? AlternativeTitle { get; set; }

        public string? Overview { get; set; }

        public string? UrlName { get; set; }
    }
}
