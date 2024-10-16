using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DFC.App.ExploreCareers.ViewModels.ExploreCareers
{
    [ExcludeFromCodeCoverage]
    public class BodyViewModel
    {
        public List<JobCategoryViewModel>? JobCategories { get; set; }

        public List<SharedContent>? SharedContents { get; set; }
    }
}
