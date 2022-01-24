using System;

using DFC.App.ExploreCareers.Data.Models.ContentModels;
using DFC.App.ExploreCareers.ViewModels;

namespace DFC.App.ExploreCareers.UnitTests.TestData
{
    public static class TestDataFactory
    {
        public static JobCategoryContentItemModel BuildJobCategoryContentItemModel()
        {
            var model = new JobCategoryContentItemModel()
            {
                Id = Guid.NewGuid(),
                Etag = Guid.NewGuid().ToString(),
                Title = "an-article",
                CanonicalName = "an-article",
                PageLocation = "/an-article"
            };

            return model;
        }

        public static JobCategoryViewModel BuildJobCategoryViewModel()
        {
            var model = new JobCategoryViewModel()
            {
                Name = "an-article",
                CanonicalName = "an-article",
            };

            return model;
        }
    }
}
