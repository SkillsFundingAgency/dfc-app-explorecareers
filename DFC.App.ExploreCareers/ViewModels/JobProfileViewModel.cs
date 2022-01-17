using System;
using System.Collections.Generic;

namespace DFC.App.ExploreCareers.ViewModels
{
    public class JobProfileViewModel
    {
        public int Rank { get; set; }

        public string? ResultItemTitle { get; set; }

        public string? ResultItemAlternativeTitle { get; set; }

        public string? ResultItemOverview { get; set; }

        public string? ResultItemSalaryRange { get; set; }

        public string? ResultItemUrlName { get; set; }

        public IList<string> JobProfileCategoriesWithUrl { get; set; } = Array.Empty<string>();

        public double Score { get; set; }

        public bool ShouldDisplayCaveat { get; internal set; }

        public int? MatchingSkillsCount { get; set; }
    }
}
