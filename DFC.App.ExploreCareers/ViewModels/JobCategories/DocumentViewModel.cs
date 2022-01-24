using System.Diagnostics.CodeAnalysis;

namespace DFC.App.ExploreCareers.ViewModels.JobCategories
{
    [ExcludeFromCodeCoverage]
    public class DocumentViewModel
    {
        public HeadViewModel Head { get; set; } = new HeadViewModel();

        public BreadcrumbViewModel? Breadcrumb { get; set; }

        public BodyViewModel? Body { get; set; }
    }
}
