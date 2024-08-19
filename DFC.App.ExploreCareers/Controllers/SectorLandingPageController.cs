using DFC.App.ExploreCareers.Extensions;
using DFC.App.ExploreCareers.GraphQl;
using DFC.App.ExploreCareers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.Controllers
{
    [Route("sector-landing-page")]
    public class SectorLandingPageController : Controller
    {
        public const string SectorLandingPageViewCanonicalName = "sector-landing-page";
        public const string DefaultPageTitleSuffix = "Explore careers";

        private readonly ILogger<SectorLandingPageController> logger;
        private readonly IJobSectorService jobSectorService;

        public SectorLandingPageController(ILogger<SectorLandingPageController> logger, 
            IJobSectorService jobSectorService)
        {
            this.logger = logger;
            this.jobSectorService = jobSectorService;
        }

        public async Task<IActionResult> Document(string JobSectorTitle)
        {
            var jobSectors = await jobSectorService.LoadAll();

            return View(null);
        }
    }
}
