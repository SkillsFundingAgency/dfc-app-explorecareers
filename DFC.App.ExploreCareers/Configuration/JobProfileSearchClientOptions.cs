using System.Diagnostics.CodeAnalysis;

namespace DFC.App.ExploreCareers.Configuration
{
    [ExcludeFromCodeCoverage]
    public class JobProfileSearchClientOptions
    {
        public string ApiKey { get; set; } = string.Empty;

        public string BaseAddress { get; set; } = string.Empty;

        public string IndexName { get; set; } = string.Empty;
    }
}
