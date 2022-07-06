using System.Diagnostics.CodeAnalysis;

namespace DFC.App.ExploreCareers.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class JobCategoryViewModel
    {
        public string Name { get; set; } = string.Empty;

        public string CanonicalName { get; set; } = string.Empty;
    }
}
