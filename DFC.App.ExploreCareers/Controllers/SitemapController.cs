using System.Linq;
using System.Net.Mime;

using DFC.App.ExploreCareers.Extensions;
using DFC.App.ExploreCareers.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DFC.App.ExploreCareers.Controllers
{
    public class SitemapController : Controller
    {
        public const string SitemapViewCanonicalName = "sitemap";

        private readonly ILogger<SitemapController> logger;

        public SitemapController(ILogger<SitemapController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        [Route("/sitemap")]
        [Route("/sitemap.xml")]
        public IActionResult Sitemap()
        {
            logger.LogInformation("Generating Sitemap");

            // TODO: change this
            var sitemapUrlPrefix = $"{Request.GetBaseAddress()}";
            var sitemap = new Sitemap();

            // add the defaults
            sitemap.Add(new SitemapLocation
            {
                Url = sitemapUrlPrefix,
                Priority = 1,
            });

            if (!sitemap.Locations.Any())
            {
                return NoContent();
            }

            var xmlString = sitemap.WriteSitemapToString();

            logger.LogInformation("Generated Sitemap");

            return Content(xmlString, MediaTypeNames.Application.Xml);
        }
    }
}