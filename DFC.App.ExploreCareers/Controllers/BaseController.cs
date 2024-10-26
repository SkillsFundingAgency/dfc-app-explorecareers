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

                    //new BreadcrumbItemViewModel()
                    //{
                    //    Route = $"/{ExploreCareersController.ExploreCareersViewCanonicalName}",
                    //    Title = BradcrumbTitle,
                    //},
                },
            };

            if (breadcrumbItemModel?.Title != null &&
                !breadcrumbItemModel.Title.Equals(BradcrumbTitle, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(breadcrumbItemModel.Route))
            {
                if (breadcrumbItemModel.Route == "#")
                {
                    var exploreCareeBreadCrumPath = new BreadcrumbItemViewModel()
                    {
                        Route = $"../{ExploreCareersController.ExploreCareersViewCanonicalName}",
                        Title = BradcrumbTitle,
                    };

                    viewModel.Breadcrumbs.Add(exploreCareeBreadCrumPath);
                }

                if (breadcrumbItemModel.Route == "job-sector")
                {
                    var exploreCareeBreadCrumPath = new BreadcrumbItemViewModel()
                    {
                        Route = $"../../../{ExploreCareersController.ExploreCareersViewCanonicalName}",
                        Title = BradcrumbTitle,
                    };

                    viewModel.Breadcrumbs.Add(exploreCareeBreadCrumPath);


                    var articlePathJobSectorPathViewModel = new BreadcrumbItemViewModel
                    {
                        Route = $"../../../{JobProfileSectorController.JobSectorsViewCanonicalName}",
                        Title = "Explore by job sector",
                    };

                    viewModel.Breadcrumbs.Add(articlePathJobSectorPathViewModel);
                }


                if (breadcrumbItemModel.Title == "All careers")
                {

                    var exploreCareeBreadCrumPath = new BreadcrumbItemViewModel()
                    {
                        Route = $"../../../{ExploreCareersController.ExploreCareersViewCanonicalName}",
                        Title = BradcrumbTitle,
                    };

                    viewModel.Breadcrumbs.Add(exploreCareeBreadCrumPath);

                    var articlePathJobSectorPathViewModel = new BreadcrumbItemViewModel
                    {
                        Route = $"../../../{JobProfileSectorController.JobSectorsViewCanonicalName}",
                        Title = "Explore by job sector",
                    };

                    viewModel.Breadcrumbs.Add(articlePathJobSectorPathViewModel);

                    var articlePathJobProfilePathViewModel = new BreadcrumbItemViewModel
                    {
                        Route = $"../../{JobProfileSectorController.JobSectorsViewCanonicalName}/{breadcrumbItemModel.AlternativeTitle}",
                        Title = breadcrumbItemModel.Route,
                    };

                    viewModel.Breadcrumbs.Add(articlePathJobProfilePathViewModel);
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
