using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DFC.App.ExploreCareers.ViewModels.JobCategories
{
    [ExcludeFromCodeCoverage]
    public class BodyViewModel
    {
        public string? Title { get; set; }

        public List<JobCategoryViewModel> JobCategories { get; set; } = new List<JobCategoryViewModel>();

        public List<JobProfileByCategoryViewModel> JobProfiles { get; set; } = new List<JobProfileByCategoryViewModel>();
    }
}
