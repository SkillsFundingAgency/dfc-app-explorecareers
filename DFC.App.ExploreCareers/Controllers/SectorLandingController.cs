using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DFC.App.ExploreCareers.Extensions;
using DFC.App.ExploreCareers.GraphQl;
using DFC.App.ExploreCareers.Interfaces;
using DFC.App.ExploreCareers.ViewModels;
using DFC.App.ExploreCareers.ViewModels.SectorLandingPage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DFC.App.ExploreCareers.Controllers
{
    [Route("sector-landing-page")]
    public class SectorLandingController : BaseController
    {
        public const string SectorLandingViewCanonicalName = "sector-landing-page";
        public const string DefaultPageTitleSuffix = "Explore careers";

        private readonly ILogger<SectorLandingController> logger;
        private readonly ISectorLandingService sectorLandingService;

        public SectorLandingController(
            ILogger<SectorLandingController> logger,
            ISectorLandingService sectorLandingService)
        {
            this.logger = logger;
            this.sectorLandingService = sectorLandingService;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var sectors = await sectorLandingService.LoadAll();

            return this.NegotiateContentResult(sectors);
        }

        [HttpGet]
        [Route("DetailsPage")]
        public async Task<IActionResult> DetailsPage(string? pageUrl)
        {
            var sectors = await sectorLandingService.GetItemByKey(pageUrl);

            return this.NegotiateContentResult(sectors);
        }
    }
}
