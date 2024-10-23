using DFC.App.ExploreCareers.Extensions;
using DFC.App.ExploreCareers.Interfaces;
using DFC.App.ExploreCareers.ViewModels;
using DFC.App.ExploreCareers.ViewModels.JobProfileSector;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.Controllers
{
    [Route("explore-careers/job-sector")]
    public class JobProfileSectorController : BaseController
    {
        public const string JobSectorsViewCanonicalName = "explore-careers/job-sector";
        public const string DefaultPageTitleSuffix = "Job Sector | Explore careers";

        private readonly ILogger<JobProfileSectorController> logger;
        private readonly IJobSectorService jobSectorService;
        private readonly ISpeakToAnAdvisorService speakToAnAdvisorService;

        public JobProfileSectorController(
            ILogger<JobProfileSectorController> logger,
            IJobSectorService jobSectorService,
            ISpeakToAnAdvisorService speakToAnAdvisorService)
        {
            this.logger = logger;
            this.jobSectorService = jobSectorService;
            this.speakToAnAdvisorService = speakToAnAdvisorService;
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
            var jobSectors = await LoadAndProcessJobSectorsAsync();
            if (jobSectors == null) return null;

            var speakToAnAdvisorKey = "Speak to an adviser";
            var sharedContent = await speakToAnAdvisorService.GetItemByKey(speakToAnAdvisorKey);

            var viewModel = new DocumentViewModel
            {
                Head = GetHeadViewModel(),
                Breadcrumb = BuildBreadcrumb("Explore by job sector"),
                Body = new BodyViewModel { 
                    JobProfileSectors = jobSectors,
                    SharedContents = sharedContent, // speak to an adviser content
                }
            };

            return viewModel;
        }

        private async Task<BodyViewModel?> CreateBodyViewModelAsync()
        {
            var jobSectors = await LoadAndProcessJobSectorsAsync();
            if (jobSectors == null) return null;

            var bodyViewModel = new BodyViewModel { JobProfileSectors = jobSectors };
            return bodyViewModel;
        }


        private async Task<List<JobProfileSector>?> LoadAndProcessJobSectorsAsync()
        {

            // Load all job sectors from the repository
            var jobSectors = await jobSectorService.LoadAll();
            if (jobSectors == null) return null;

            // Limit to a maximum of 15 cards and process each job sector
            jobSectors = jobSectors.Take(15).ToList();
            foreach (var jobProfile in jobSectors)
            {
                var urlName = string.Empty;

                if (jobProfile.SectorLandingPage != null &&
                  jobProfile.SectorLandingPage.ContentItems != null &&
                  jobProfile.SectorLandingPage.ContentItems.Any())
                {
                    urlName = jobProfile.SectorLandingPage.ContentItems
                                .Select(x => x.PageLocation?.UrlName)
                                .FirstOrDefault() ?? string.Empty;
                }
            }

            return jobSectors;
        }

        private static void UpdateJobSectorsWithGridHtml(List<JobProfileSector> jobSectors, List<string> gridHtml)
        {
            for (int i = 0; i < gridHtml.Count; i++)
            {
                if (i < jobSectors.Count)
                {
                    jobSectors[i].Render = gridHtml[i];
                }
                else
                {
                    jobSectors.Add(new JobProfileSector { Render = gridHtml[i] });
                }
            }
        }

        private HeadViewModel GetHeadViewModel(string? pageTitle = null)
        {
            return new HeadViewModel
            {
                CanonicalUrl = new Uri($"{Request.GetBaseAddress()}/{JobSectorsViewCanonicalName}", UriKind.RelativeOrAbsolute),
                Title = string.IsNullOrWhiteSpace(pageTitle)
                    ? DefaultPageTitleSuffix
                    : $"{pageTitle} | {DefaultPageTitleSuffix}"
            };
        }

        private static BreadcrumbViewModel BuildBreadcrumb(string title) =>
            BuildBreadcrumb(new Models.BreadcrumbItemModel { Title = title, Route = "#" });
    }
}
