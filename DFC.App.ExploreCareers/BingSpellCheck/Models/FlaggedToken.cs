using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DFC.App.ExploreCareers.BingSpellCheck.Models
{
    public class FlaggedToken
    {
        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("suggestions")]
        public IEnumerable<Suggestion> Suggestions { get; set; } = Array.Empty<Suggestion>();
    }
}