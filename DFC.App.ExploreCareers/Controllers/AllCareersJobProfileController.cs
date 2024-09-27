using DFC.App.ExploreCareers.Extensions;
using DFC.App.ExploreCareers.Interfaces;
using DFC.App.ExploreCareers.ViewModels;
using DFC.App.ExploreCareers.ViewModels.AllCareersJobProfile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.Controllers
{
    [Route("explore-careers/all-careers")]
    public class AllCareersJobProfileController : BaseController
    {
        public const string AllCareersJobeProfileViewCanonicalName = "all-careers";
        public const string DefaultPageTitleSuffix = "Explore careers | All Careers";

        private readonly ILogger<AllCareersJobProfileController> logger;
        private readonly IJobProfileService jobProfileService;

        public AllCareersJobProfileController(
            ILogger<AllCareersJobProfileController> logger,
            IJobProfileService jobProfileService)
        {
            this.logger = logger;
            this.jobProfileService = jobProfileService;
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
        public IActionResult BodyTop(string titleUrl)
        {
            logger.LogInformation($"{nameof(BodyTop)} has returned content");
            return this.NegotiateContentResult(null);
        }

        [HttpGet]
        [Route("document")]
        public async Task<IActionResult> DocumentAsync()
        {

            var selectedCategoryIds = Request.Query["selectedCategoryIds"].ToList();

            // Check if 'clearFilters' exists in the query string and its value is true
            var clearFilters = Request.Query["clearFilters"].ToString() == "true";


            if (clearFilters == true)
            {
                selectedCategoryIds = null;
            }

            var viewModel = await CreateDocumentViewModelAsync(selectedCategoryIds);
            if (viewModel == null)
            {
                return NotFound();
            }

            return this.NegotiateContentResult(viewModel);
        }

        private async Task<DocumentViewModel?> CreateDocumentViewModelAsync(List<string>? selectedCategoryIds = null)
        {
            // Retrieve all job profiles
            var allCareersJobProfile = await jobProfileService.GetAllJobProfile(selectedCategoryIds);


            // Retrieve all job profiles categories
            var allJobCategories = await jobProfileService.GetAllCategories();


            // If there are no job profiles, return null
            if (allCareersJobProfile == null) return null;

            // Create a HashSet to store distinct category content items based on ContentItemId
            var categoryContentItems = new HashSet<JobProfileCategoryContentItem>(new JobProfileCategoryContentItemComparer());

            // Loop through all job profiles
            foreach (var jobProfile in allCareersJobProfile)
            {
                // Check if the job profile has categories
                if (jobProfile.JobProfileCategory?.ContentItems != null)
                {
                    // Loop through each content item in the job profile's category
                    foreach (var categoryItem in jobProfile.JobProfileCategory.ContentItems)
                    {
                        // Add to the HashSet to ensure distinct items (based on ContentItemId)
                        categoryContentItems.Add(categoryItem);
                    }
                }
            }

            //// Order the distinct category items by DisplayText after ensuring distinctness
            //var orderedCategoryContentItems = categoryContentItems
            //    .OrderBy(item => item.DisplayText)
            //    .ToList();

            // Build the view model
            var viewModel = new DocumentViewModel
            {
                Head = GetHeadViewModel(),
                Breadcrumb = BuildBreadcrumb("All careers"),
                Body = new BodyViewModel
                {
                    JobProfile = allCareersJobProfile,
                    CategoryContentItems = allJobCategories,
                    selectedCategoryIds = selectedCategoryIds
                }
            };

            return viewModel;
        }

        private HeadViewModel GetHeadViewModel(string? pageTitle = null)
        {
            return new HeadViewModel
            {
                CanonicalUrl = new Uri($"{Request.GetBaseAddress()}/{AllCareersJobeProfileViewCanonicalName}", UriKind.RelativeOrAbsolute),
                Title = string.IsNullOrWhiteSpace(pageTitle)
                    ? DefaultPageTitleSuffix
                    : $"{pageTitle} | {DefaultPageTitleSuffix}"
            };
        }

        private static BreadcrumbViewModel BuildBreadcrumb(string title) =>
           BuildBreadcrumb(new Models.BreadcrumbItemModel { Title = title, Route = "#" });
    }
}
