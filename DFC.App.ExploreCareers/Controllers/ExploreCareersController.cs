using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using DFC.App.ExploreCareers.Data.Models.ContentModels;
using DFC.App.ExploreCareers.Extensions;
using DFC.App.ExploreCareers.ViewModels;
using DFC.App.ExploreCareers.ViewModels.ExploreCareers;
using DFC.Compui.Cosmos.Contracts;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DFC.App.ExploreCareers.Controllers
{
    [Route("explore-careers")]
    public class ExploreCareersController : Controller
    {
        public const string ExploreCareersViewCanonicalName = "explore-careers";
        public const string DefaultPageTitleSuffix = "Explore Careers | National Careers Service";

        private readonly ILogger<ExploreCareersController> logger;
        private readonly IMapper mapper;
        private readonly IDocumentService<JobCategoryContentItemModel> documentService;

        public ExploreCareersController(
            ILogger<ExploreCareersController> logger,
            IMapper mapper,
            IDocumentService<JobCategoryContentItemModel> documentService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.documentService = documentService;
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
            var viewModel = new DocumentViewModel
            {
                Head = GetHeadViewModel(),
                Body = await GetBodyViewModelAsync(),
            };

            logger.LogInformation($"{nameof(DocumentAsync)} has returned content");
            return this.NegotiateContentResult(viewModel);
        }

        [HttpGet]
        [Route("body")]
        public async Task<IActionResult> BodyAsync()
        {
            BodyViewModel viewModel = await GetBodyViewModelAsync();

            logger.LogInformation($"{nameof(BodyAsync)} has returned content");
            return this.NegotiateContentResult(viewModel);
        }

        private HeadViewModel GetHeadViewModel(string? pageTitle = null)
        {
            return new HeadViewModel
            {
                CanonicalUrl = new Uri($"{Request.GetBaseAddress()}/{ExploreCareersViewCanonicalName}", UriKind.RelativeOrAbsolute),
                Title = string.IsNullOrWhiteSpace(pageTitle) ? DefaultPageTitleSuffix : $"{pageTitle} | {DefaultPageTitleSuffix}",
            };
        }

        private async Task<BodyViewModel> GetBodyViewModelAsync()
        {
            var jobCategoryDocuments = await documentService.GetAllAsync() ?? Enumerable.Empty<JobCategoryContentItemModel>();
            var jobCategories = mapper.Map<List<JobCategoryViewModel>>(jobCategoryDocuments);

            return new BodyViewModel { JobCategories = jobCategories };
        }
    }
}
