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
    [Route("job-sectors")]
    public class JobProfileSectorController : BaseController
    {
        public const string JobCategoryViewCanonicalName = "job-sectors";
        public const string DefaultPageTitleSuffix = "Explore careers";

        private readonly ILogger<JobProfileSectorController> logger;
        private readonly IJobSectorService sectorRepository;

        public JobProfileSectorController(
            ILogger<JobProfileSectorController> logger,
            IJobSectorService sectorRepository)
        {
            this.logger = logger;
            this.sectorRepository = sectorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var jobSectors = await sectorRepository.LoadAll();

            return this.NegotiateContentResult(jobSectors);
        }

    }
}
