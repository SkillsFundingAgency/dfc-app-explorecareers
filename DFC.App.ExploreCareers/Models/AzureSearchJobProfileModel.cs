using System;
using System.Collections.Generic;

using DFC.App.ExploreCareers.AzureSearch;

namespace DFC.App.ExploreCareers.Models
{
    public class AzureSearchJobProfileModel
    {
        public IEnumerable<JobProfileIndex> JobProfiles { get; set; } = Array.Empty<JobProfileIndex>();

        public int TotalResults { get; set; }
    }
}
