using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

namespace DFC.App.ExploreCareers.BingSpellCheck
{
    public class SpellCheckService : ISpellCheckService
    {
        public const string OcpApimSubscriptionKey = "Ocp-Apim-Subscription-Key";

        private readonly ILogger<SpellCheckService> logger;
        private readonly HttpClient client;

        public SpellCheckService(ILogger<SpellCheckService> logger, HttpClient client)
        {
            this.logger = logger;
            this.client = client;
        }

        public async Task<SpellCheckResult> CheckSpellingAsync(string term)
        {
            if (!string.IsNullOrWhiteSpace(term))
            {
                try
                {
                    var values = new Dictionary<string, string> { { "text", term } };
                    using var content = new FormUrlEncodedContent(values);
                    var response = await client.PostAsync(string.Empty, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var resultsString = await response.Content.ReadAsByteArrayAsync();
                        var suggestions = System.Text.Json.JsonSerializer.Deserialize<BingResponse>(resultsString);
                        if (suggestions.flaggedTokens.Length > 0)
                        {
                            foreach (var tokenTerm in suggestions.flaggedTokens)
                            {
                                term = term.Replace(tokenTerm.token, tokenTerm.suggestions[0].suggestion, StringComparison.OrdinalIgnoreCase);
                            }

                            return new SpellCheckResult
                            {
                                CorrectedTerm = term,
                                HasCorrected = true
                            };
                        }
                    }
                }
                catch (Exception e)
                {
                    logger.LogError(e, "Failed to call bing spell check service.");
                }
            }

            return new SpellCheckResult();
        }
    }
}
