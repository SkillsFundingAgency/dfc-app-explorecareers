using AutoMapper;
using DFC.App.ExploreCareers.AzureSearch;
using DFC.App.ExploreCareers.Extensions;
using DFC.App.ExploreCareers.Models;
using DFC.App.ExploreCareers.ViewModels.SearchResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.Controllers
{
    public class SearchResultsController : BasePagesController<SearchResultsController>
    {
        private readonly IAzureSearchService<JobProfileSearchClientOptions> azureSearchService;
        private readonly IAutoCompleteService<JobCategorySearchClientOptions> autoCompleteService;
        private readonly IMapper mapper;

        public SearchResultsController(ILogger<SearchResultsController> logger, IAzureSearchService<JobProfileSearchClientOptions> azureSearchService, IAutoCompleteService<JobCategorySearchClientOptions> autoCompleteService, IMapper mapper) : base(logger)
        {
            this.autoCompleteService = autoCompleteService;
            this.mapper = mapper;
            this.azureSearchService = azureSearchService;
        }

        [HttpPost]
        [Route("search-results/body")]
        public async Task<IActionResult> Post(string SearchTerm)
        {
            var searchResults = await azureSearchService.Search(SearchTerm, 1).ConfigureAwait(false);
            var viewModel = mapper.Map<SearchResultsViewModel>(searchResults);
            viewModel.CurrentPage = 1;
            viewModel.SearchTerm = SearchTerm;
            Logger.LogWarning($"{nameof(Body)} has not returned any content for: {SearchTerm}");
            return this.NegotiateContentResult(viewModel, null, "Body");
        }

        [Route("search-results/breadcrumb")]
        public async Task<IActionResult> Breadcrumb(string? article)
        {
            var viewModel = BuildBreadcrumb(RegistrationPath, new BreadcrumbItemModel{BreadcrumbTitle = "Search results", CanonicalName = "search-results" });

            Logger.LogInformation($"{nameof(Breadcrumb)} has returned content for: {article}");

            return this.NegotiateContentResult(viewModel);
        }

        [HttpGet]
        [Route("search-results/body")]
        public async Task<IActionResult> Body(string SearchTerm, int page = 1)
        {
            var searchResults = await azureSearchService.Search(SearchTerm, page).ConfigureAwait(false);
            var viewModel = mapper.Map<SearchResultsViewModel>(searchResults);
            viewModel.CurrentPage = page;
            viewModel.SearchTerm = SearchTerm;

            Logger.LogWarning($"{nameof(Body)} has not returned any content for: {SearchTerm}");
            return this.NegotiateContentResult(viewModel, null, "Body");
        }

        [HttpGet, HttpPost]
        [Route("JobProfileSearchAuto")]
        public async Task<IActionResult> JobProfileSearchAuto(string term)
        {
            var occupations = await autoCompleteService.AutoComplete(term).ConfigureAwait(false);

            if (!occupations.Any())
                return NoContent();

            return this.Ok(occupations);
        }
    }
}
