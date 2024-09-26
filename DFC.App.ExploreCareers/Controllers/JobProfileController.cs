using DFC.App.ExploreCareers.Extensions;
using DFC.App.ExploreCareers.Interfaces;
using DFC.App.ExploreCareers.ViewModels;
using DFC.App.ExploreCareers.ViewModels.JobProfile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.Controllers
{
    [Route("explore-careers/job-sector/all-careers")]
    public class JobProfileController : BaseController
    {
        public const string JobProfilesViewCanonicalName = "job-profiles";
        public const string DefaultPageTitleSuffix = "Explore careers | All Careers";

        private readonly ILogger<JobProfileController> logger;
        private readonly IJobProfileService jobProfileService;

        public JobProfileController(
           ILogger<JobProfileController> logger,
           IJobProfileService jobProfileService)
        {
            this.logger = logger;
            this.jobProfileService = jobProfileService;
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
        public IActionResult BodyTop(string titleUrl)
        {
            logger.LogInformation($"{nameof(BodyTop)} has returned content");
            return this.NegotiateContentResult(null);
        }

        [HttpGet]
        [Route("document")]
        public async Task<IActionResult> DocumentAsync()
        {
            var contentItemId = Request.Query["id"].ToString();
            var jobSector = Request.Query["sector-page"].ToString();

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

        private async Task<DocumentViewModel?> CreateDocumentViewModelAsync(string key)
        {
            var jobProfiles = await jobProfileService.GetItemByKey(key);

            if (jobProfiles == null) return null;

            var viewModel = new DocumentViewModel
            {
                Head = GetHeadViewModel(),
                Breadcrumb = BuildBreadcrumb("All careers"),
                Body = new BodyViewModel { JobProfile = jobProfiles }
            };

            //ViewData["displayText"] = viewModel.Body.JobProfile;

            return viewModel;
        }

        private HeadViewModel GetHeadViewModel(string? pageTitle = null)
        {
            return new HeadViewModel
            {
                CanonicalUrl = new Uri($"{Request.GetBaseAddress()}/{JobProfilesViewCanonicalName}", UriKind.RelativeOrAbsolute),
                Title = string.IsNullOrWhiteSpace(pageTitle)
                    ? DefaultPageTitleSuffix
                    : $"{pageTitle} | {DefaultPageTitleSuffix}"
            };
        }

        private static BreadcrumbViewModel BuildBreadcrumb(string title) =>
            BuildBreadcrumb(new Models.BreadcrumbItemModel { Title = title, Route = "#" });
    }
}
