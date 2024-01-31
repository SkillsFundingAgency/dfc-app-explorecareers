using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using DFC.App.ExploreCareers.AzureSearch;
using DFC.App.ExploreCareers.Cosmos;
using DFC.App.ExploreCareers.Extensions;
using DFC.App.ExploreCareers.ViewModels;
using DFC.App.ExploreCareers.ViewModels.JobCategories;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DFC.App.ExploreCareers.Controllers
{
    [Route("job-categories")]
    public class JobCategoriesController : BaseController
    {
        public const string JobCategoryViewCanonicalName = "job-categories";
        public const string DefaultPageTitleSuffix = "Explore careers";

        private readonly ILogger<JobCategoriesController> logger;
        private readonly IMapper mapper;
        private readonly IJobCategoryDocumentService documentService;
        private readonly IAzureSearchService azureSearchService;

        public JobCategoriesController(
            ILogger<JobCategoriesController> logger,
            IMapper mapper,
            IJobCategoryDocumentService documentService,
            IAzureSearchService azureSearchService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.documentService = documentService;
            this.azureSearchService = azureSearchService;
        }

        [HttpGet]
        [Route("{category}/breadcrumb")]
        public async Task<IActionResult> Breadcrumb(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                return BadRequest();
            }

            var jobCategories = await documentService.GetJobCategoriesAsync($"/{category}");
            var jobCategory = jobCategories.FirstOrDefault(c => c.CanonicalName == category);

            if (jobCategory is null)
            {
                return NotFound();
            }

            var viewModel = BuildBreadcrumb(jobCategory.Name);

            logger.LogInformation($"{nameof(Head)} has returned content");
            return this.NegotiateContentResult(viewModel);
        }

        [HttpGet]
        [Route("{category}/head")]
        public IActionResult Head(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                return BadRequest();
            }

            var viewModel = GetHeadViewModel(category);

            logger.LogInformation($"{nameof(Head)} has returned content");
            return this.NegotiateContentResult(viewModel);
        }

        [HttpGet]
        [Route("{category}/body")]
        public async Task<IActionResult> Body(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                return BadRequest();
            }

            BodyViewModel viewModel = await GetBodyViewModelAsync(category);

            if (string.IsNullOrWhiteSpace(viewModel.Title))
            {
                return NotFound();
            }

            logger.LogInformation($"{nameof(Body)} has returned content");
            return this.NegotiateContentResult(viewModel);
        }

        [HttpGet]
        [Route("{category}")]
        [Route("{category}/document")]
        public async Task<IActionResult> Document(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                return BadRequest();
            }

            BodyViewModel bodyViewModel = await GetBodyViewModelAsync(category);

            if (string.IsNullOrWhiteSpace(bodyViewModel.Title))
            {
                return NotFound();
            }

            var viewModel = new DocumentViewModel
            {
                Body = bodyViewModel,
                Head = GetHeadViewModel(category),
                Breadcrumb = BuildBreadcrumb(bodyViewModel.Title)
            };

            logger.LogInformation($"{nameof(Document)} has returned content");
            return this.NegotiateContentResult(viewModel);
        }

        private static BreadcrumbViewModel BuildBreadcrumb(string title) =>
            BuildBreadcrumb(new Models.BreadcrumbItemModel { Title = title, Route = "#" });

        private static string GetTitle(string category)
        {
            var title = category.Replace('-', ' ');
            return $"{char.ToUpper(title[0], System.Globalization.CultureInfo.CurrentCulture)}{title[1..]} | {DefaultPageTitleSuffix}";
        }

        private HeadViewModel GetHeadViewModel(string category) =>
            new HeadViewModel
            {
                CanonicalUrl = new Uri($"{Request.GetBaseAddress()}{JobCategoryViewCanonicalName}", UriKind.RelativeOrAbsolute),
                Title = string.IsNullOrWhiteSpace(category) ? DefaultPageTitleSuffix : GetTitle(category),
            };

        private async Task<BodyViewModel> GetBodyViewModelAsync(string category)
        {
            var jobCategories = await documentService.GetJobCategoriesAsync();
            if (!jobCategories.Any(c => c.CanonicalName == category))
            {
                return new BodyViewModel();
            }

            var jobProfiles = await azureSearchService.GetProfilesByCategoryAsync(category);

            return new BodyViewModel
            {
                Title = jobCategories.FirstOrDefault(c => c.CanonicalName == category)?.Name,
                JobCategories = jobCategories.Where(c => c.CanonicalName != category).ToList(),
                JobProfiles = mapper.Map<List<JobProfileByCategoryViewModel>>(jobProfiles)
            };
        }
    }
}
