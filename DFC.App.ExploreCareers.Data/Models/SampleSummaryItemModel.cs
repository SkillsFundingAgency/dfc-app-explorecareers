using DFC.App.ExploreCareers.Data.Contracts;
using System;

namespace DFC.App.ExploreCareers.Data.Models
{
    public class SampleSummaryItemModel : IApiDataModel
    {
        public Uri? Url { get; set; }

        public string? CanonicalName { get; set; }

        public DateTime Published { get; set; }
    }
}
