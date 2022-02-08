using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.BingSpellCheck.Models;

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
                        var suggestions = JsonSerializer.Deserialize<BingResponse>(resultsString);
                        if (suggestions.FlaggedTokens.Any())
                        {
                            foreach (var tokenTerm in suggestions.FlaggedTokens.Where(s => s.Suggestions.Any()))
                            {
                                term = term.Replace(tokenTerm.Token, tokenTerm.Suggestions.First().Value, StringComparison.OrdinalIgnoreCase);
                            }

                            logger.LogInformation($"Bing Spell check corrected term: {term}");
                            return new SpellCheckResult
                            {
                                CorrectedTerm = term,
                                HasCorrected = true
                            };
                        }

                        logger.LogInformation($"Bing Spell check didn't return any corrections.");
                    }

                    logger.LogWarning($"Bing Spell check api call failed. Response: {await response.Content.ReadAsStringAsync()}");
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
