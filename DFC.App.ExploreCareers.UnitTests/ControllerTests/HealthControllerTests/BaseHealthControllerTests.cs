﻿using System.Collections.Generic;
using System.Net.Mime;

using DFC.App.ExploreCareers.Controllers;
using DFC.App.ExploreCareers.Data.Models.ContentModels;
using DFC.Compui.Cosmos.Contracts;

using FakeItEasy;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace DFC.App.ExploreCareers.UnitTests.ControllerTests.HealthControllerTests
{
    public class BaseHealthControllerTests
    {
        public BaseHealthControllerTests()
        {
            FakeDocumentService = A.Fake<IDocumentService<JobCategoryContentItemModel>>();
            FakeLogger = A.Fake<ILogger<HealthController>>();
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

        protected IDocumentService<JobCategoryContentItemModel> FakeDocumentService { get; }

        protected ILogger<HealthController> FakeLogger { get; }

        protected HealthController BuildHealthController(string mediaTypeName)
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers[HeaderNames.Accept] = mediaTypeName;

            var controller = new HealthController(FakeLogger, FakeDocumentService)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                },
            };

            return controller;
        }
    }
}
