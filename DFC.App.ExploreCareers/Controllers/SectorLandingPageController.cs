﻿using DFC.App.ExploreCareers.Extensions;
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
    [Route("sector-landing-page")]
    public class SectorLandingPageController : BaseController
    {
        public const string SectorLandingPageViewCanonicalName = "sector-landing-page";
        public const string DefaultPageTitleSuffix = "Explore careers";

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
        [Route("{titleUrl}/head")]
        public IActionResult Head()
        {
            var viewModel = GetHeadViewModel();

            logger.LogInformation($"{nameof(Head)} has returned content");
            return this.NegotiateContentResult(viewModel);
        }

        [HttpGet]
        [Route("{titleUrl}/bodytop")]
        public IActionResult BodyTop(string titleUrl)
        {
            logger.LogInformation($"{nameof(BodyTop)} has returned content");
            return this.NegotiateContentResult(null);
        }

        [HttpGet]
        [Route("{titleUrl}")]
        [Route("{titleUrl}/document")]
        public async Task<IActionResult> Document(string titleUrl)
        {
            var contentItemId = Request.Query["id"].ToString();

            // Check if contentItemId is "0" or invalid
            if (contentItemId == "0")
            {
                // Return an empty view model if contentItemId is 0 or invalid
                var emptyViewModel = new DocumentViewModel(); // Create an empty instance of the view model
                return this.NegotiateContentResult(emptyViewModel); // Return the empty view model
            }

            var viewModel = await CreateDocumentViewModelAsync(contentItemId);
            if (viewModel == null)
            {
                return NotFound();
            }

            return this.NegotiateContentResult(viewModel);
        }


        [HttpGet]
        [Route("{titleUrl}/body")]
        public async Task<IActionResult> BodyAsync(string titleUrl)
        {
            var contentItemId = Request.Query["id"].ToString();

            var bodyViewModel = await CreateBodyViewModelAsync(titleUrl);
            if (bodyViewModel == null)
            {
                return NotFound();
            }

            logger.LogInformation($"{nameof(BodyAsync)} has returned content");
            return this.NegotiateContentResult(bodyViewModel);
        }

        [HttpGet]
        public IActionResult RedirectToJobsProfile(string displayText, string contentItemId)
        {
            // Store the contentItemId in TempData to pass it to the GET action
            TempData["ContentItemId"] = contentItemId;

            // Redirect to DocumentAsync GET method with displayText in the URL (jobSector)
            return RedirectToAction("DocumentAsync", "job-profiles", new { jobSector = displayText });
        }


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
                Head = GetHeadViewModel(),
                Breadcrumb = BuildBreadcrumb(sectorLandingPages[0].DisplayText),
                Body = new BodyViewModel { SectorLandingPage = sectorLandingPages }
            };

            ////await Task.Delay(1, cancellationToken: default).ConfigureAwait(false);

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

        private HeadViewModel GetHeadViewModel(string? pageTitle = null)
        {
            return new HeadViewModel
            {
                CanonicalUrl = new Uri($"{Request.GetBaseAddress()}/{SectorLandingPageViewCanonicalName}", UriKind.RelativeOrAbsolute),
                Title = string.IsNullOrWhiteSpace(pageTitle)
                    ? DefaultPageTitleSuffix
                    : $"{pageTitle} | {DefaultPageTitleSuffix}"
            };
        }

        private static BreadcrumbViewModel BuildBreadcrumb(string title) =>
             BuildBreadcrumb(new Models.BreadcrumbItemModel { Title = title, Route = "#" });
    }
}
