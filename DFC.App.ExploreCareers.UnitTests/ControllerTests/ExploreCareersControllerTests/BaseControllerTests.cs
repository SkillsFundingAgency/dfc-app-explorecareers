
using System;

using AutoMapper;

using DFC.App.ExploreCareers.Controllers;
using DFC.App.ExploreCareers.Data.Models.ContentModels;
using DFC.App.ExploreCareers.ViewModels;
using DFC.Compui.Cosmos.Contracts;

using FakeItEasy;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace DFC.App.ExploreCareers.UnitTests.ControllerTests.ExploreCareersControllerTests
{
    public abstract class BaseControllerTests
    {
        protected BaseControllerTests()
        {
            FakeDocumentService = A.Fake<IDocumentService<JobCategoryContentItemModel>>();
            FakeLogger = A.Fake<ILogger<ExploreCareersController>>();
            FakeMapper = A.Fake<IMapper>();
        }

        protected IDocumentService<JobCategoryContentItemModel> FakeDocumentService { get; }

        protected ILogger<ExploreCareersController> FakeLogger { get; }

        protected IMapper FakeMapper { get; }

        protected ExploreCareersController BuildController(string mediaTypeName)
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers[HeaderNames.Accept] = mediaTypeName;

            var controller = new ExploreCareersController(FakeLogger, FakeMapper, FakeDocumentService)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                },
            };

            return controller;
        }

        protected JobCategoryContentItemModel BuildValidContentItemModel()
        {
            var model = new JobCategoryContentItemModel()
            {
                Id = Guid.NewGuid(),
                Etag = Guid.NewGuid().ToString(),
                Title = "an-article",
                CanonicalName = "an-article",
                PageLocation = "/an-article"
            };

            return model;
        }

        protected JobCategoryViewModel BuildValidViewModel()
        {
            var model = new JobCategoryViewModel()
            {
                Name = "an-article",
                CanonicalName = "an-article",
            };

            return model;
        }
    }
}
