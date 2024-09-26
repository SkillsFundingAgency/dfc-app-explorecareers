using DFC.App.ExploreCareers.ViewModels.AllCareersJobProfile;
using System.Collections.Generic;

namespace DFC.App.ExploreCareers.Extensions
{
    public class JobProfileCategoryContentItemComparer : IEqualityComparer<JobProfileCategoryContentItem>
    {
        public bool Equals(JobProfileCategoryContentItem x, JobProfileCategoryContentItem y)
        {
            // Check if the ContentItemId is the same
            return x?.ContentItemId == y?.ContentItemId;
        }

        public int GetHashCode(JobProfileCategoryContentItem obj)
        {
            // Use ContentItemId's hash code
            return obj.ContentItemId?.GetHashCode() ?? 0;
        }
    }

}
