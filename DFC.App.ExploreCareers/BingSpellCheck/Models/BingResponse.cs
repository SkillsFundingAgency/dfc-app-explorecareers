using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DFC.App.ExploreCareers.BingSpellCheck.Models
{
    public class BingResponse
    {
        [JsonPropertyName("_type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("flaggedTokens")]
        public IEnumerable<FlaggedToken> FlaggedTokens { get; set; } = Array.Empty<FlaggedToken>();
    }
}
