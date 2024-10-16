using System;
using System.Threading.Tasks;
using DFC.App.ExploreCareers.Extensions;
using DFC.App.ExploreCareers.GraphQl;
using DFC.App.ExploreCareers.Interfaces;
using DFC.App.ExploreCareers.ViewModels;
using DFC.App.ExploreCareers.ViewModels.ExploreCareers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DFC.App.ExploreCareers.Controllers
{
    [Route("explore-careers")]
    public class ExploreCareersController : Controller
    {
        public const string ExploreCareersViewCanonicalName = "explore-careers";
        public const string DefaultPageTitleSuffix = "Explore careers | National Careers Service";

        private readonly ILogger<ExploreCareersController> logger;
        private readonly IGraphQlService graphQlService;
        private readonly ISpeakToAnAdvisorService speakToAnAdvisorService;

        public ExploreCareersController(
            ILogger<ExploreCareersController> logger,
            IGraphQlService graphQlService,
            ISpeakToAnAdvisorService speakToAnAdvisorService)
        {
            this.logger = logger;
            this.graphQlService = graphQlService;
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
            var viewModel = new DocumentViewModel
            {
                //Head = GetHeadViewModel(),
                Body = await GetBodyViewModelAsync(),
            };

            logger.LogInformation($"{nameof(DocumentAsync)} has returned content");
            return this.NegotiateContentResult(viewModel);
        }

        //[HttpGet]
        //[Route("body")]
        //public async Task<IActionResult> BodyAsync()
        //{
        //    BodyViewModel viewModel = await GetBodyViewModelAsync();

        //    logger.LogInformation($"{nameof(BodyAsync)} has returned content");
        //    return this.NegotiateContentResult(viewModel);
        //}

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
            var speakToAnAdvisorKey = "Speak to an adviser";

            var jobCategories = await graphQlService.GetJobCategoriesAsync();

            var sharedContent = await speakToAnAdvisorService.GetItemByKey(speakToAnAdvisorKey);

            return new BodyViewModel { JobCategories = jobCategories, SharedContents = sharedContent };
        }
    }
}
