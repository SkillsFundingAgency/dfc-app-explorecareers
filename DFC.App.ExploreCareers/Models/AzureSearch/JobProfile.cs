using System.Collections.Generic;

namespace DFC.App.ExploreCareers.Models.AzureSearch
{
    public class JobProfile
    {
        public string Title { get; set; }

        public List<string> AlternativeTitle { get; set; } = new List<string>();

        public string Overview { get; set; }

        public decimal SalaryStarter { get; set; }

        public decimal SalaryExperienced { get; set; }

        public string UrlName { get; set; }

        public List<string> JobProfileCategoriesWithUrl { get; set; } = new List<string>();
    }
}
