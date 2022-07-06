using System.Text.Json.Serialization;

namespace DFC.App.ExploreCareers.BingSpellCheck.Models
{
    public class Suggestion
    {
        [JsonPropertyName("suggestion")]
        public string Value { get; set; } = string.Empty;

        [JsonPropertyName("score")]
        public float Score { get; set; }
    }
}