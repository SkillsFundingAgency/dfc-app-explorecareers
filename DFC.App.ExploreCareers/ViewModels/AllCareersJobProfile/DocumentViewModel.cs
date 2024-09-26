namespace DFC.App.ExploreCareers.ViewModels.AllCareersJobProfile
{
    public class DocumentViewModel
    {
        public HeadViewModel Head { get; set; } = new HeadViewModel();

        public BreadcrumbViewModel? Breadcrumb { get; set; }

        public BodyViewModel? Body { get; set; }
    }
}
