using System;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using DFC.App.ExploreCareers.Extensions;
using DFC.App.ExploreCareers.GraphQl;
using DFC.App.ExploreCareers.Interfaces;
using DFC.App.ExploreCareers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DFC.App.ExploreCareers.Controllers
{
    public class SitemapController : Controller
    {
        public const string SitemapViewCanonicalName = "sitemap";

        private readonly ILogger<SitemapController> logger;
        private readonly IGraphQlService graphQlService;

        public SitemapController(ILogger<SitemapController> logger, IGraphQlService graphQlService)
        {
            this.logger = logger;
            this.graphQlService = graphQlService;
        }

        [HttpGet]
        [Route("/sitemap")]
        [Route("/sitemap.xml")]
        public async Task<IActionResult> Sitemap()
        {
            logger.LogInformation("Generating Sitemap");

            var sitemap = new Sitemap();

            AddExploreCareersRoutes();
            await AddJobCategoriesRoutesAsync();
            AddJobSectosRoutesAsync();

            if (!sitemap.Locations.Any())
            {
                return NoContent();
            }

            var xmlString = sitemap.WriteSitemapToString();

            logger.LogInformation("Generated Sitemap");

            return Content(xmlString, MediaTypeNames.Application.Xml);

            void AddExploreCareersRoutes()
            {
                var exploreCareersUrlPrefix = $"{Request.GetBaseAddress()}{ExploreCareersController.ExploreCareersViewCanonicalName}";
                sitemap.Add(new SitemapLocation
                {
                    Url = exploreCareersUrlPrefix,
                    ChangeFrequency = SitemapLocation.ChangeFrequencies.Monthly,
                    Priority = 0.5,
                });
            }

            async Task AddJobCategoriesRoutesAsync()
            {
                try
                {
                    var jobCategories = await graphQlService.GetJobCategoriesAsync();
                    if (jobCategories?.Any() is true)
                    {
                        var jobCategoriesUrlPrefix = $"{Request.GetBaseAddress()}{JobCategoriesController.JobCategoryViewCanonicalName}";

                        sitemap.AddRange(jobCategories.Select(jc => new SitemapLocation
                        {
                            Url = $"{jobCategoriesUrlPrefix}/{jc.CanonicalName}",
                            ChangeFrequency = SitemapLocation.ChangeFrequencies.Monthly,
                            Priority = 0.5,
                        }));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            void AddJobSectosRoutesAsync()
            {
                var jobSectosUrlPrefix = $"{Request.GetBaseAddress()}{JobProfileSectorController.JobSectorsViewCanonicalName}";

                sitemap.Add(new SitemapLocation
                {
                    Url = $"{jobSectosUrlPrefix}",
                    ChangeFrequency = SitemapLocation.ChangeFrequencies.Monthly,
                    Priority = 0.5,
                });
            }
        }
    }
}