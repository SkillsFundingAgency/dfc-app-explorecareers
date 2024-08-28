using DFC.App.ExploreCareers.Extensions;
using DFC.App.ExploreCareers.Interfaces;
using DFC.App.ExploreCareers.ViewModels;
using DFC.App.ExploreCareers.ViewModels.SectorLandingPage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.Controllers
{
    [Route("sector-landing-page/{title}")]
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
        [Route("head")]
        public IActionResult Head()
        {
            var viewModel = GetHeadViewModel();

            logger.LogInformation($"{nameof(Head)} has returned content");
            return this.NegotiateContentResult(viewModel);
        }

        [HttpGet]
        [Route("bodytop")]
        public IActionResult BodyTop()
        {
            logger.LogInformation($"{nameof(BodyTop)} has returned content");
            return this.NegotiateContentResult(null);
        }

        [HttpGet]
        [Route("")]
        [Route("document")]
        public async Task<IActionResult> Document(string JobSectorTitle)
        {
            var viewModel = await CreateDocumentViewModelAsync();
            if (viewModel == null)
            {
                return NotFound();
            }

            return this.NegotiateContentResult(viewModel);

            //return View("~/Views/SectorLandingPage/Document.cshtml");
        }

        [HttpGet]
        [Route("body")]
        public async Task<IActionResult> BodyAsync()
        {
            var bodyViewModel = await CreateBodyViewModelAsync();
            if (bodyViewModel == null)
            {
                return NotFound();
            }

            logger.LogInformation($"{nameof(BodyAsync)} has returned content");
            return this.NegotiateContentResult(bodyViewModel);
        }

        private async Task<DocumentViewModel?> CreateDocumentViewModelAsync()
        {

            //var sectorLandingPage = await jobSectorService.GetItemByKey("4rsm1xx8j2c81sgdgfjw6nhqnh");

            var viewModel = new DocumentViewModel
            {
                Head = GetHeadViewModel(),
                Breadcrumb = BuildBreadcrumb("Agriculture, environmental and animal care"),
                Body = new BodyViewModel { SectorLandingPage = "test" }
            };

            await Task.Delay(1, cancellationToken: default).ConfigureAwait(false);

            return viewModel;
        }

        private async Task<BodyViewModel?> CreateBodyViewModelAsync()
        {
            var bodyViewModel = new BodyViewModel { SectorLandingPage = "test" };

            await Task.Delay(1, cancellationToken: default).ConfigureAwait(false);

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
