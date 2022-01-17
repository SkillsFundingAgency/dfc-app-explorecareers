using System.Threading.Tasks;

using AutoMapper;

using DFC.App.ExploreCareers.AzureSearch;
using DFC.App.ExploreCareers.Extensions;
using DFC.App.ExploreCareers.Models;
using DFC.App.ExploreCareers.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DFC.App.ExploreCareers.Controllers
{
    [Route("search-results")]
    public class SearchResultsController : BaseController
    {
        public const string SearchResultsCanonicalName = "search-results";

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

        [Route("breadcrumb")]
        public IActionResult Breadcrumb()
        {
            var viewModel = BuildBreadcrumb(new BreadcrumbItemModel { Route = "Search results", Title = "search-results" });

            logger.LogInformation($"{nameof(Breadcrumb)} has returned content.");

            return this.NegotiateContentResult(viewModel);
        }

        [HttpGet]
        [Route("body")]
        public async Task<IActionResult> Body(string searchTerm, int page = 1)
        {
            var searchResults = await azureSearchService.Search(searchTerm, page);
            var viewModel = mapper.Map<SearchResultsViewModel>(searchResults);
            viewModel.CurrentPage = page;
            viewModel.SearchTerm = searchTerm;

            logger.LogWarning($"{nameof(Body)} has not returned any content for: {searchTerm}");
            return this.NegotiateContentResult(viewModel, null);
        }
    }
}
