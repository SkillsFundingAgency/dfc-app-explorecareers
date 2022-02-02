using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DFC.App.ExploreCareers.AzureSearch
{
    public static class SearchBuilder
    {
        private const string AzureSearchSpecialChar = @"[*+^""~?<>/]|( -)|[!]|[()]|[{}]|[\[\]]|&&|&|\|\|";

        public static string BuildSearchExpression(string searchTerm, string cleanedSearchTerm, string partialTermToSearch)
        {
            _ = searchTerm ?? throw new ArgumentNullException(nameof(searchTerm));
            _ = cleanedSearchTerm ?? throw new ArgumentNullException(nameof(cleanedSearchTerm));
            _ = partialTermToSearch ?? throw new ArgumentNullException(nameof(partialTermToSearch));

            return (searchTerm == "*") ? searchTerm :
                $"{nameof(JobProfileIndex.Title)}:({partialTermToSearch.ToLowerInvariant()}) {nameof(JobProfileIndex.AlternativeTitle)}:({partialTermToSearch.ToLowerInvariant()}) {nameof(JobProfileIndex.TitleAsKeyword)}:\"{searchTerm.ToLower()}\" {nameof(JobProfileIndex.AltTitleAsKeywords)}:\"{searchTerm.ToLowerInvariant()}\" {cleanedSearchTerm}";
        }

        public static string BuildContainPartialSearch(string cleanedSearchTerm)
        {
            var trimmedTerm = Regex.Replace(cleanedSearchTerm, @"\s+", " ").Trim();

            var computedContains = trimmedTerm.Any(char.IsWhiteSpace)
                ? trimmedTerm.Split(' ').Aggregate(string.Empty, ProcessSingleWord)
                : trimmedTerm.Contains("-", StringComparison.OrdinalIgnoreCase) ? trimmedTerm : CreateContainTerm(trimmedTerm);

            return computedContains.Trim();

            static string ProcessSingleWord(string current, string term) =>
                $"{current} " + (term.Contains("-", StringComparison.OrdinalIgnoreCase) ? term.Trim() : CreateContainTerm(term));

            static string CreateContainTerm(string term) =>
                $"/.*{term}.*/";
        }

        public static string TrimCommonWordsAndSuffixes(string searchTerm)
        {
            var result = searchTerm?.Any(char.IsWhiteSpace) is true
                ? searchTerm.Split(' ').Aggregate(string.Empty, ProcessSingleWord)
                : TrimAndReplaceSuffixOnCurrentTerm(searchTerm!);

            return result.Trim();

            static string ProcessSingleWord(string current, string term) =>
                IsCommonCojoinginWord(term) ? $"{current}" : $"{current} {TrimAndReplaceSuffixOnCurrentTerm(term)}";
        }

        public static string RemoveSpecialCharactersFromTheSearchTerm(string searchTerm)
        {
            var regex = new Regex(AzureSearchSpecialChar);
            var result = regex.Replace(searchTerm, string.Empty);
            return $"{Regex.Replace(result.Trim(), @"\s+", " ")}";
        }

        private static bool IsCommonCojoinginWord(string term)
        {
            var commonWords = new[]
            {
                "and",
                "or",
                "as",
                "if",
                "also",
                "but",
                "not",
            };

            return commonWords.Any(w => w.Equals(term, StringComparison.OrdinalIgnoreCase));
        }

        private static string TrimAndReplaceSuffixOnCurrentTerm(string term)
        {
            var trimmedWord = TrimSuffixFromSingleWord(term);
            var replaceSuffix = ReplaceSuffixFromSingleWord(trimmedWord);
            return replaceSuffix;
        }

        private static string TrimSuffixFromSingleWord(string searchTerm)
        {
            var suffixes = new[]
            {
                "er",
                "ers",
                "ing",
                "ment",
                "ation",
                "or",
                "metry",
                "ics",
                "ette",
                "ance",
                "ies",
                "macy",
            };

            var suffixToBeTrimmed = suffixes.FirstOrDefault(s => searchTerm.EndsWith(s, StringComparison.OrdinalIgnoreCase));
            var trimmedResult = suffixToBeTrimmed is null ? searchTerm : searchTerm.Substring(0, searchTerm.LastIndexOf(suffixToBeTrimmed, StringComparison.OrdinalIgnoreCase));
            return trimmedResult.Length < 3 ? searchTerm : trimmedResult;
        }

        private static string ReplaceSuffixFromSingleWord(string trimmedWord)
        {
            var replaceSuffixDictionary = new Dictionary<string, string>
            {
                ["therapy"] = "thera",
                ["ology"] = "olo",
            };

            var suffixToBeTrimmed = replaceSuffixDictionary.FirstOrDefault(s => trimmedWord.EndsWith(s.Key, StringComparison.OrdinalIgnoreCase));
            var trimmedResult = suffixToBeTrimmed.Key is null
                ? trimmedWord
                : $"{trimmedWord.Substring(0, trimmedWord.LastIndexOf(suffixToBeTrimmed.Key, StringComparison.OrdinalIgnoreCase))}{suffixToBeTrimmed.Value}";
            return trimmedResult.Length < 3 ? trimmedWord : trimmedResult;
        }
    }
}
