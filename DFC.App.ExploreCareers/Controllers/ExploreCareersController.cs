using DFC.App.ExploreCareers.Data.Models;
using DFC.App.ExploreCareers.Extensions;
using DFC.App.ExploreCareers.ViewModels.ExploreCareers;
using DFC.Compui.Cosmos.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.Controllers
{
    public class ExploreCareersController : BasePagesController<ExploreCareersController>
    {
        private readonly IDocumentService<JobCategory> jobCategoryPageDocumentService;

        public ExploreCareersController(ILogger<ExploreCareersController> logger, IDocumentService<JobCategory> jobCategoryPageDocumentService) : base(logger)
        {
            this.jobCategoryPageDocumentService = jobCategoryPageDocumentService;
        }

        [Route("/breadcrumb")]
        public async Task<IActionResult> Breadcrumb()
        {
            var viewModel = BuildBreadcrumb(RegistrationPath, null);

            return this.NegotiateContentResult(viewModel);
        }

        [HttpGet]
        [Route("/body")]
        public async Task<IActionResult> Body()
        {
            var viewModel = new BodyViewModel();
            var jobCategories = await jobCategoryPageDocumentService.GetAllAsync().ConfigureAwait(false);

            viewModel.JobCategory = new JobCategory();

            if (jobCategories?.FirstOrDefault() != null)
            {
                viewModel.JobCategory = jobCategories.FirstOrDefault();
            }

            return this.NegotiateContentResult(viewModel);
        }
    }
}