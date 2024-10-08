using DFC.App.ExploreCareers.Extensions;
using DFC.App.ExploreCareers.Interfaces;
using DFC.App.ExploreCareers.ViewModels;
using DFC.App.ExploreCareers.ViewModels.SectorLandingPage;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.Controllers
{
    [Route("explore-careers")]
    public class SectorLandingPageController : BaseController
    {
        public const string SectorLandingPageViewCanonicalName = "explore-careers";
        public const string DefaultPageTitleSuffix = "Sector landing page | Explore careers ";

        private readonly ILogger<SectorLandingPageController> logger;
        private readonly IJobSectorService jobSectorService;

        public SectorLandingPageController(
            ILogger<SectorLandingPageController> logger,
            IJobSectorService jobSectorService)
        {
            this.logger = logger;
            this.jobSectorService = jobSectorService;
        }

        [HttpGet]
        [Route("head/job-sector/{sectorName}")]
        public IActionResult Head(string sectorName)
        {
            var viewModel = GetHeadViewModel();

            logger.LogInformation($"{nameof(Head)} has returned content");
            return this.NegotiateContentResult(viewModel);
        }

        [HttpGet]
        [Route("bodytop/job-sector/{sectorName}")]
        public IActionResult BodyTop()
        {
            logger.LogInformation($"{nameof(BodyTop)} has returned content");
            return this.NegotiateContentResult(null);
        }

        [HttpGet]
        [Route("document/job-sector/{sectorName}")]
        public async Task<IActionResult> Document(string sectorName)
        {
            var contentItemId = Request.Query["id"].ToString();

            var titleUrl = Request.Query["sector-page"].ToString();

            // Check if contentItemId is "0" or invalid
            if (contentItemId == "0")
            {
                // Return an empty view model if contentItemId is 0 or invalid
                var emptyViewModel = new DocumentViewModel(); // Create an empty instance of the view model
                return this.NegotiateContentResult(emptyViewModel); // Return the empty view model
            }

            var viewModel = await CreateDocumentViewModelAsync(sectorName);
            if (viewModel == null)
            {
                return NotFound();
            }

            return this.NegotiateContentResult(viewModel);
        }

        //[HttpGet]
        //[Route("body/job-sector/{sectorName}")]
        //public async Task<IActionResult> BodyAsync()
        //{
        //    var contentItemId = Request.Query["id"].ToString();
        //    var titleUrl = Request.Query["sector-page"].ToString();

        //    var bodyViewModel = await CreateBodyViewModelAsync(titleUrl);
        //    if (bodyViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    logger.LogInformation($"{nameof(BodyAsync)} has returned content");
        //    return this.NegotiateContentResult(bodyViewModel);
        //}

        private async Task<DocumentViewModel?> CreateDocumentViewModelAsync(string key)
        {
            var jobSectors = await jobSectorService.GetItemByKey(key);

            if (jobSectors == null) return null;

            List<SectorLandingPage> sectorLandingPages = new List<SectorLandingPage>();

            foreach (var item in jobSectors)
            {
                sectorLandingPages = item.SectorLandingPageSearchResults;
            }

            var viewModel = new DocumentViewModel
            {
                Head = GetHeadViewModel(sectorLandingPages[0].DisplayText),
                Breadcrumb = BuildBreadcrumb(sectorLandingPages[0].DisplayText),
                Body = new BodyViewModel { SectorLandingPage = sectorLandingPages }
            };

            return viewModel;
        }

        private async Task<BodyViewModel?> CreateBodyViewModelAsync(string key)
        {
            var jobSectors = await jobSectorService.GetItemByKey(key);

            if (jobSectors == null) return null;

            List<SectorLandingPage> sectorLandingPages = new List<SectorLandingPage>();

            foreach (var item in jobSectors)
            {
                sectorLandingPages = item.SectorLandingPageSearchResults;
            }

            var bodyViewModel = new BodyViewModel { SectorLandingPage = sectorLandingPages };

            return bodyViewModel;
        }

        private HeadViewModel GetHeadViewModel(string titleUrl = null)
        {
            var pageTitle = titleUrl; // Use the titleUrl as the page title
            var pageTitleSuffix = DefaultPageTitleSuffix.Replace("Sector landing page", pageTitle); // Replace {titleUrl} with actual value

            return new HeadViewModel
            {
                CanonicalUrl = new Uri($"{Request.GetBaseAddress()}/{SectorLandingPageViewCanonicalName}", UriKind.RelativeOrAbsolute),
                Title = $"{pageTitleSuffix}" // Set the dynamic title here
            };
        }

        private static BreadcrumbViewModel BuildBreadcrumb(string title) =>
             BuildBreadcrumb(new Models.BreadcrumbItemModel { Title = title, Route = "job-sector" });
    }
}
