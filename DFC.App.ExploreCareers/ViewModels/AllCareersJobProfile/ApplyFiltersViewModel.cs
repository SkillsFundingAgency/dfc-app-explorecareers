using System.Collections.Generic;

namespace DFC.App.ExploreCareers.ViewModels.AllCareersJobProfile
{
    public class ApplyFiltersViewModel
    {
        public List<string> SelectedCategoryIds { get; set; } = new List<string>(); // For the ContentItemIds

        public List<string> DisplayTexts { get; set; } = new List<string>(); // To hold the DisplayText values
    }
}
