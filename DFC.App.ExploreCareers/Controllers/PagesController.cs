using System.Collections.Generic;

using DFC.App.ExploreCareers.Extensions;
using DFC.App.ExploreCareers.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace DFC.App.ExploreCareers.Controllers
{
    public class PagesController : Controller
    {
        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            var viewModel = new IndexViewModel()
            {
                Documents = new List<IndexDocumentViewModel>()
                {
                    new IndexDocumentViewModel { Title = HealthController.HealthViewCanonicalName },
                    new IndexDocumentViewModel { Title = SitemapController.SitemapViewCanonicalName },
                    new IndexDocumentViewModel { Title = RobotController.RobotsViewCanonicalName },
                    new IndexDocumentViewModel { Title = ExploreCareersController.ExploreCareersViewCanonicalName },
                    new IndexDocumentViewModel { Title = JobProfileSectorController.JobSectorsViewCanonicalName },
                    new IndexDocumentViewModel { Title = TestController.SectorLandingPageViewCanonicalName },
                },
            };

            return this.NegotiateContentResult(viewModel);
        }
    }
}