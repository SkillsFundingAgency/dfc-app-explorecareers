using DFC.App.ExploreCareers.Extensions;
using DFC.App.ExploreCareers.Interfaces;
using DFC.App.ExploreCareers.ViewModels;
using DFC.App.ExploreCareers.ViewModels.JobProfile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.Controllers
{
    [Route("job-profiles")]
    public class JobProfileController : BaseController
    {
        public const string JobProfilesViewCanonicalName = "job-profiles";
        public const string DefaultPageTitleSuffix = "Explore careers | Job Profile";

        private readonly ILogger<JobProfileController> logger;
        private readonly IJobSectorService jobSectorService;

        public JobProfileController(
           ILogger<JobProfileController> logger,
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
        public async Task<IActionResult> DocumentAsync()
        {
            var viewModel = await CreateDocumentViewModelAsync();
            if (viewModel == null)
            {
                return NotFound();
            }

            return this.NegotiateContentResult(viewModel);
        }

        private async Task<DocumentViewModel?> CreateDocumentViewModelAsync()
        {
            var jobSectors = new List<JobProfile>();
            if (jobSectors == null) return null;

            var viewModel = new DocumentViewModel
            {
                Head = GetHeadViewModel(),
                Breadcrumb = BuildBreadcrumb("Explore by job sector"),
                Body = new BodyViewModel { JobProfile = jobSectors }
            };

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
