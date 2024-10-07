using System;
using System.Collections.Generic;
using System.Linq;

using DFC.App.ExploreCareers.Models;
using DFC.App.ExploreCareers.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace DFC.App.ExploreCareers.Controllers
{
    public class BaseController : Controller
    {
        protected static BreadcrumbViewModel BuildBreadcrumb(BreadcrumbItemModel? breadcrumbItemModel)
        {
            const string BradcrumbTitle = "Explore Careers";



            var viewModel = new BreadcrumbViewModel
            {
                Breadcrumbs = new List<BreadcrumbItemViewModel>()
                {
                    new BreadcrumbItemViewModel()
                    {
                        Route = "/",
                        Title = "Home",
                    },
                    new BreadcrumbItemViewModel()
                    {
                        Route = $"/{ExploreCareersController.ExploreCareersViewCanonicalName}",
                        Title = BradcrumbTitle,
                    },
                },
            };

            if (breadcrumbItemModel?.Title != null &&
                !breadcrumbItemModel.Title.Equals(BradcrumbTitle, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(breadcrumbItemModel.Route))
            {
                if (breadcrumbItemModel.Route == "job-sector")
                {
                    var articlePathJobSectorPathViewModel = new BreadcrumbItemViewModel
                    {
                        Route = $"/{JobProfileSectorController.JobSectorsViewCanonicalName}",
                        Title = "Explore by job sector",
                    };

                    viewModel.Breadcrumbs.Add(articlePathJobSectorPathViewModel);
                }

                var articlePathViewModel = new BreadcrumbItemViewModel
                {
                    Route = breadcrumbItemModel.Route,
                    Title = breadcrumbItemModel.Title,
                };

                viewModel.Breadcrumbs.Add(articlePathViewModel);
            }

            viewModel.Breadcrumbs.Last().AddHyperlink = false;

            return viewModel;
        }
    }
}
