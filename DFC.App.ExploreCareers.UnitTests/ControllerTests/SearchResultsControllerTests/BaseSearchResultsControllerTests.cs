using AutoMapper;
using DFC.App.ExploreCareers.AzureSearch;
using DFC.App.ExploreCareers.Controllers;
using DFC.App.ExploreCareers.Data.Models;
using DFC.Compui.Cosmos.Contracts;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Mime;

namespace DFC.App.ExploreCareers.UnitTests.ControllerTests.SearchResultsControllerTests
{
    public abstract class BaseSearchResultsControllerTests
    {
        protected const string LocalPath = "explore-careers";

        protected BaseSearchResultsControllerTests()
        {
            Logger = A.Fake<ILogger<SearchResultsController>>();
            FakeDocumentService = A.Fake<IDocumentService<JobCategory>>();
            FakAutoCompleteService = A.Fake<IAutoCompleteService<JobCategorySearchClientOptions>>();
            FakeAzureSearchService = A.Fake<IAzureSearchService<JobProfileSearchClientOptions>>();
            FakeMapper = A.Fake<IMapper>();
        }

        public static IEnumerable<object[]> HtmlMediaTypes => new List<object[]>
        {
            new string[] { "*/*" },
            new string[] { MediaTypeNames.Text.Html },
        };

        public static IEnumerable<object[]> InvalidMediaTypes => new List<object[]>
        {
            new string[] { MediaTypeNames.Text.Plain },
        };

        public static IEnumerable<object[]> JsonMediaTypes => new List<object[]>
        {
            new string[] { MediaTypeNames.Application.Json },
        };

        protected ILogger<SearchResultsController> Logger { get; }

        protected IDocumentService<JobCategory> FakeDocumentService { get; }

        protected IAzureSearchService<JobProfileSearchClientOptions> FakeAzureSearchService { get; }

        protected IAutoCompleteService<JobCategorySearchClientOptions> FakAutoCompleteService { get; }

        protected IMapper FakeMapper { get; }

        protected SearchResultsController BuildSearchResultsController()
        {
            var httpContext = new DefaultHttpContext();

            var controller = new SearchResultsController(Logger, FakeAzureSearchService, FakAutoCompleteService, FakeMapper)
                {
                    ControllerContext = new ControllerContext()
                    {
                        HttpContext = httpContext,
                    }
                };

            controller.Request.Headers.Add(ConstantStrings.CompositeSessionIdHeaderName, Guid.NewGuid().ToString());

            return controller;
        }
    }
}
