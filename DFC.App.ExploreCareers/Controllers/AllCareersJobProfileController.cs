using DFC.App.ExploreCareers.Extensions;
using DFC.App.ExploreCareers.Interfaces;
using DFC.App.ExploreCareers.ViewModels;
using DFC.App.ExploreCareers.ViewModels.AllCareersJobProfile;
using Microsoft.AspNetCore.Http;
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
        public const string AllCareersJobeProfileViewCanonicalName = "View all careers";
        public const string DefaultPageTitleSuffix = "All Careers | Explore careers";

        private readonly ILogger<AllCareersJobProfileController> logger;
        private readonly IJobProfileService jobProfileService;
        private readonly ISpeakToAnAdvisorService speakToAnAdvisorService;

        public AllCareersJobProfileController(
            ILogger<AllCareersJobProfileController> logger,
            IJobProfileService jobProfileService,
            ISpeakToAnAdvisorService speakToAnAdvisorService)
        {
            this.logger = logger;
            this.jobProfileService = jobProfileService;
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
        public IActionResult BodyTop(string titleUrl)
        {
            logger.LogInformation($"{nameof(BodyTop)} has returned content");
            return this.NegotiateContentResult(null);
        }

        [HttpGet]
        //[Route("")]
        [Route("document")]
        //public async Task<IActionResult> DocumentAsync([FromQuery] int page = 0, int pageSize = 20)
        public async Task<IActionResult> DocumentAsync()
        {
            //int skip = (page - 1) * pageSize; // Calculate how many records to skip for pagination
            var selectedCategoryIds = Request.Query["selectedCategoryIds"].ToList();

            // Try to parse 'page' and 'pageSize' to integers, use default values if parsing fails
            int page = 0; // Default page number
            int pageSize = 20; // Default page size

            if (!string.IsNullOrEmpty(Request.Query["page"]))
            {
                int.TryParse(Request.Query["page"], out page); // If it fails, page will remain the default value (1)
            }

            if (!string.IsNullOrEmpty(Request.Query["pageSize"]))
            {
                int.TryParse(Request.Query["pageSize"], out pageSize); // If it fails, pageSize will remain the default value (20)
            }


            // Check if 'clearFilters' exists in the query string and its value is true
            var clearFilters = Request.Query["clearFilters"].ToString() == "true";

            if (clearFilters == true)
            {
                selectedCategoryIds = null;
                HttpContext.Session.Remove("selectedCategoryIds");
                HttpContext.Session.Clear();

                // Redirect back to the base URL without query parameters
                //return RedirectToAction("Document", new { page = 0, pageSize = 20 });
                //return Redirect($"../explore-careers/all-careers");

                //return RedirectToAction("document", "explore-careers/all-careers");
            }

            if (selectedCategoryIds != null && selectedCategoryIds.Count > 0)
            {
                HttpContext.Session.Remove("selectedCategoryIds");
                HttpContext.Session.Clear();
                var serializedSelectedCategoryIds = JsonConvert.SerializeObject(selectedCategoryIds);
                HttpContext.Session.SetString("selectedCategoryIds", serializedSelectedCategoryIds);
            }
            else if (page == 0)
            {
                page = 1;
                HttpContext.Session.Remove("selectedCategoryIds");
                HttpContext.Session.Clear();
            }

            int skip = page == 0 ? 0 * pageSize : (page - 1) * pageSize; // Calculate how many records to skip for pagination

            // Retrieve the data from session
            var sessionData = HttpContext.Session.GetString("selectedCategoryIds");

            // If data exists in session, deserialize it back to a list
            if (!string.IsNullOrEmpty(sessionData))
            {
                selectedCategoryIds = JsonConvert.DeserializeObject<List<string>>(sessionData);
            }

            var viewModel = await CreateDocumentViewModelAsync(selectedCategoryIds, skip, pageSize);

            if (viewModel == null)
            {
                return NotFound();
            }

            return this.NegotiateContentResult(viewModel);
        }


        // Set or update string list in session
        public void SetStringListInSession(List<string> selectedCategoryIds)
        {
            // Store the list in session
            HttpContext.Session.SetString("StringList", JsonConvert.SerializeObject(selectedCategoryIds));
        }

        private async Task<DocumentViewModel?> CreateDocumentViewModelAsync(List<string>? selectedCategoryIds = null, int skip = 0, int pageSize = 20)
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

            // Apply pagination logic
            var paginatedJobProfiles = allCareersJobProfile
                .Skip(skip) // Skip the number of records for pagination
                .Take(pageSize) // Take the required number of records for the current page
                .ToList();

            var totalJobProfilesCount = allCareersJobProfile.Count();

            var startIndex = skip + 1; // The starting index of the results for the current page

            var endIndex = Math.Min(skip + pageSize, totalJobProfilesCount); // The ending index of the results for the current page

            var speakToAnAdvisorKey = "Speak to an adviser";
            var sharedContent = await speakToAnAdvisorService.GetItemByKey(speakToAnAdvisorKey);

            // Build the view model
            var viewModel = new DocumentViewModel
            {
                Head = GetHeadViewModel(),
                Breadcrumb = BuildBreadcrumb(AllCareersJobeProfileViewCanonicalName),
                Body = new BodyViewModel
                {
                    JobProfile = paginatedJobProfiles,  // Use paginated job profiles
                    CategoryContentItems = allJobCategories,
                    selectedCategoryIds = selectedCategoryIds,

                    SharedContents = sharedContent, // speak to an adviser content
                    // Pagination properties
                    PageNumber = (skip / pageSize) + 1,  // Calculate current page
                    PageSize = pageSize,
                    TotalResults = totalJobProfilesCount,
                    TotalPages = (int)Math.Ceiling((double)totalJobProfilesCount / pageSize),

                    // Start and end index for the current page
                    StartIndex = startIndex,
                    EndIndex = endIndex
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
