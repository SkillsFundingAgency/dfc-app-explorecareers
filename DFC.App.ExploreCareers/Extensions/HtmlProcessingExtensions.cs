using DFC.App.ExploreCareers.ViewModels.JobProfileSector;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DFC.App.ExploreCareers.Extensions
{
    public static class HtmlProcessingExtensions
    {
        public static string RearrangeHtml(string htmlContent, string? sectorPageLandingId)
        {
            // Initialize variables
            string title = "Default Title";
            string description = "Default description.";
            string imgTag = "<img src='/assets/images/default-image.png' alt='Default Image'>";

            // Extract the title
            int titleStartIndex = htmlContent.IndexOf("<h1>") + 4;
            int titleEndIndex = htmlContent.IndexOf("</h1>");
            if (titleStartIndex > 3 && titleEndIndex > titleStartIndex)
            {
                title = htmlContent.Substring(titleStartIndex, titleEndIndex - titleStartIndex).Trim();
            }

            // Extract the description
            string descriptionStartMarker = "<div class=\"field field-type-textfield field-name-job-profile-sector-description\">";
            int descriptionStartIndex = htmlContent.IndexOf(descriptionStartMarker) + descriptionStartMarker.Length;
            int descriptionEndIndex = htmlContent.IndexOf("</div>", descriptionStartIndex);
            if (descriptionStartIndex > descriptionStartMarker.Length && descriptionEndIndex > descriptionStartIndex)
            {
                description = htmlContent.Substring(descriptionStartIndex, descriptionEndIndex - descriptionStartIndex).Trim();
            }


            // Extract the image tag
            int imgStartIndex = htmlContent.IndexOf("<div class=\"field field-type-mediafield field-name-job-profile-sector-image\">") + 47;
            int imgEndIndex = htmlContent.IndexOf("</div>", imgStartIndex);
            if (imgStartIndex > 46 && imgEndIndex > imgStartIndex)
            {
                int imgTagStart = htmlContent.IndexOf("<img", imgStartIndex);
                if (imgTagStart >= 0 && imgTagStart < imgEndIndex)
                {
                    int imgTagEnd = htmlContent.IndexOf(">", imgTagStart) + 1;
                    if (imgTagEnd > imgTagStart)
                    {
                        imgTag = htmlContent.Substring(imgTagStart, imgTagEnd - imgTagStart);
                    }
                }
            }

            // Create the new HTML structure for the card
            var titleUrl = title.ToLower()
                    .Replace(" ", "-")
                    .Replace(",", string.Empty);

            var newHtml = $@"
            <div class='dfe-card dfe-card-expolore-career'>
                {imgTag}
                <div class='dfe-card-container'>
                    <h2 class='govuk-heading-m'>
                        <a href='/explore-careers/job-sector-landing?sector-page={titleUrl}&id={sectorPageLandingId}' class='govuk-link govuk-link--no-visited-state dfe-card-link--header'>{title}</a>
                    </h2>
                    <p class='dfe-card-description dfe-card-description-expolore-career'>{description}</p>
                </div>
            </div>";

            return newHtml;
        }

        public static List<string> GenerateGridHtml(List<string> cardsHtml)
        {
            //// Limit to a maximum of 15 cards
            var limitedCards = cardsHtml.Take(15).ToList();

            // Extract titles and pair with HTML
            var cardsWithTitles = limitedCards
                .Select(html => new
                {
                    Html = html,
                    Title = ExtractTitleFromHtml(html)
                })
                .OrderBy(card => card.Title, StringComparer.OrdinalIgnoreCase)
                .ToList();

            // Create a list of cards, adding placeholders if necessary
            var cards = cardsWithTitles.Select(card => card.Html).ToList();

            // Calculate the number of placeholders needed
            int placeholdersNeeded = (3 - (cards.Count % 3)) % 3;
            for (int i = 0; i < placeholdersNeeded; i++)
            {
                cards.Add("<div class='dfe-card dfe-card-placeholder'></div>");
            }

            // Generate HTML for each row
            var rows = new List<string>();

            foreach (var card in cards)
            {
                var rowHtml = $"{card}";

                rows.Add(rowHtml);
            }

            return rows;
        }

        private static string ExtractTitleFromHtml(string html)
        {
            int titleStartIndex = html.IndexOf("<h2 class='govuk-heading-m'>") + 27;
            int titleEndIndex = html.IndexOf("</a>", titleStartIndex);
            if (titleStartIndex > 26 && titleEndIndex > titleStartIndex)
            {
                return html.Substring(titleStartIndex, titleEndIndex - titleStartIndex).Trim();
            }

            return string.Empty;
        }
    }
}
