using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

using AutoMapper;

using DFC.App.ExploreCareers.AzureSearch;
using DFC.App.ExploreCareers.Extensions;
using DFC.App.ExploreCareers.Models;
using DFC.App.ExploreCareers.ViewModels;
using DFC.App.ExploreCareers.ViewModels.SearchResults;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DFC.App.ExploreCareers.Controllers
{
    [Route("search-results")]
    public class SearchResultsController : BaseController
    {
        public const string SearchResultsCanonicalName = "search-results";
        public const string DefaultPageTitleSuffix = "Search | National Careers Service";
        public const string NoResultsMessage = "0 results found - try again using a different job title";

        private readonly ILogger<SearchResultsController> logger;
        private readonly IAzureSearchService azureSearchService;
        private readonly IMapper mapper;

        public SearchResultsController(
            ILogger<SearchResultsController> logger,
            IAzureSearchService azureSearchService,
            IMapper mapper)
        {
            this.logger = logger;
            this.azureSearchService = azureSearchService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("head")]
        public IActionResult Head(string? searchTerm = "")
        {
            var viewModel = GetHeadViewModel(searchTerm!);

            logger.LogInformation($"{nameof(Head)} has returned content");
            return this.NegotiateContentResult(viewModel);
        }

        [Route("breadcrumb")]
        public IActionResult Breadcrumb()
        {
            var viewModel = GetBreadcrumbViewModel();

            logger.LogInformation($"{nameof(Breadcrumb)} has returned content.");

            return this.NegotiateContentResult(viewModel);
        }

        [HttpGet]
        [Route("body")]
        public async Task<IActionResult> Body(string? searchTerm = "", int page = 1)
        {
            BodyViewModel viewModel = await GetBodyViewModelAsync(searchTerm!, page);

            logger.LogWarning($"{nameof(Body)} has not returned any content for: {searchTerm}");
            return this.NegotiateContentResult(viewModel, null);
        }

        [HttpGet]
        [Route("")]
        [Route("document")]
        public async Task<IActionResult> Document(string? searchTerm = "", int page = 1)
        {
            var viewModel = new DocumentViewModel
            {
                Body = await GetBodyViewModelAsync(searchTerm!, page),
                Breadcrumb = GetBreadcrumbViewModel(),
                Head = GetHeadViewModel(searchTerm!)
            };

            logger.LogWarning($"{nameof(Body)} has not returned any content for: {searchTerm}");
            return this.NegotiateContentResult(viewModel, null);
        }

        private static BreadcrumbViewModel GetBreadcrumbViewModel()
        {
            return BuildBreadcrumb(new BreadcrumbItemModel { Title = "Search results", Route = "#" });
        }

        private HeadViewModel GetHeadViewModel(string searchTerm)
        {
            return new HeadViewModel
            {
                CanonicalUrl = new Uri($"{Request.GetBaseAddress()}/{SearchResultsCanonicalName}", UriKind.RelativeOrAbsolute),
                Title = string.IsNullOrWhiteSpace(searchTerm) ? DefaultPageTitleSuffix : $"{searchTerm} | {DefaultPageTitleSuffix}",
            };
        }

        private async Task<BodyViewModel> GetBodyViewModelAsync(string searchTerm, int page)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return new BodyViewModel { SearchTerm = searchTerm };
            }

            var searchResults = await azureSearchService.SearchAsync(searchTerm, page);
            int totalFound = searchResults.TotalResults;
            var viewModel = new BodyViewModel
            {
                SearchTerm = searchTerm,
                JobProfiles = mapper.Map<IEnumerable<JobProfileViewModel>>(searchResults.JobProfiles),
                TotalResults = totalFound,
                TotalResultsMessage = searchResults.TotalResults is 0 ? NoResultsMessage : GetResultsMessage(),
                PageNumber = page,
                TotalPages = (int)Math.Ceiling((double)totalFound / SearchConfig.PageSize),
            };

            SetPagination();

            return viewModel;

            string GetResultsMessage() =>
                $"{totalFound} result{(totalFound is 1 ? string.Empty : "s")} found";

            void SetPagination()
            {
                if (viewModel.TotalPages > viewModel.PageNumber)
                {
                    viewModel.NextPageUrl = $"/{SearchResultsCanonicalName}?searchTerm={HttpUtility.UrlEncode(searchTerm)}&page={viewModel.PageNumber + 1}";
                    viewModel.NextPageUrlText = $"{viewModel.PageNumber + 1} of {viewModel.TotalPages}";
                }

                if (viewModel.PageNumber > 1)
                {
                    viewModel.PreviousPageUrl = $"/{SearchResultsCanonicalName}?searchTerm={HttpUtility.UrlEncode(searchTerm)}{(viewModel.PageNumber is 2 ? string.Empty : $"&page={viewModel.PageNumber - 1}")}";
                    viewModel.PreviousPageUrlText = $"{viewModel.PageNumber - 1} of {viewModel.TotalPages}";
                }
            }
        }
    }
}
