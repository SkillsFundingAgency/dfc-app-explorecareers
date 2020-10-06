using DFC.App.ExploreCareers.Controllers;
using DFC.App.ExploreCareers.Data.Models;
using DFC.Compui.Cosmos.Contracts;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Net.Mime;

namespace DFC.App.ExploreCareers.UnitTests.ControllerTests.ExploreCareersControllerTests
{
    public abstract class BaseExploreCareersControllerTests
    {
        protected const string LocalPath = "explore-careers";

        protected BaseExploreCareersControllerTests()
        {
            Logger = A.Fake<ILogger<ExploreCareersController>>();
            FakeDocumentService = A.Fake<IDocumentService<JobCategory>>();
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

        protected ILogger<ExploreCareersController> Logger { get; }

        protected IDocumentService<JobCategory> FakeDocumentService { get; }
        
        protected ExploreCareersController BuildExploreCareersController()
        {
            var httpContext = new DefaultHttpContext();

            var controller = new ExploreCareersController(Logger, FakeDocumentService)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                },
            };

            controller.Request.Headers.Add(ConstantStrings.CompositeSessionIdHeaderName, Guid.NewGuid().ToString());

            return controller;
        }
    }
}
