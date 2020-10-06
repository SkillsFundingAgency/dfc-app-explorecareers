using System;
using System.Diagnostics.CodeAnalysis;

namespace DFC.App.ExploreCareers.Data.Models
{
    [ExcludeFromCodeCoverage]
    public class DynamicLink
    {
        public Uri? Href { get; set; }

        public string? Relationship { get; set; }
    }
}
