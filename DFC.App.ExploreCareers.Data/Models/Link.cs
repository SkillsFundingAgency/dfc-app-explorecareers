using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DFC.App.ExploreCareers.Data.Models
{
    [ExcludeFromCodeCoverage]
    public class Link
    {
        public KeyValuePair<string, DynamicLink> LinkValue { get; set; }
    }
}
