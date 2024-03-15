using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace DFC.App.ExploreCareers.AzureSearch
{
    [ExcludeFromCodeCoverage]
    public class JobProfileIndex
    {
        public string? Title { get; set; }

        public string TitleAsKeyword => Title?.ToLower() ?? string.Empty;

        public IEnumerable<string>? AlternativeTitle { get; set; }

        public IEnumerable<string>? AltTitleAsKeywords => AlternativeTitle?.Select(a => a.ToLower());

        public string? Overview { get; set; }

        public double SalaryStarter { get; set; }

        public double SalaryExperienced { get; set; }

        public string? UrlName { get; set; }

        public IEnumerable<string>? JobProfileCategoriesWithUrl { get; set; }

        public int Rank { get; set; }
    }
}
