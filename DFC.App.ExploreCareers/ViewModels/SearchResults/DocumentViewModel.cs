using System.Diagnostics.CodeAnalysis;

namespace DFC.App.ExploreCareers.ViewModels.SearchResults
{
    [ExcludeFromCodeCoverage]
    public class DocumentViewModel
    {
        public HeadViewModel Head { get; set; } = new HeadViewModel();

        public BreadcrumbViewModel Breadcrumb { get; set; } = new BreadcrumbViewModel();

        public BodyViewModel Body { get; set; } = new BodyViewModel();
    }
}
