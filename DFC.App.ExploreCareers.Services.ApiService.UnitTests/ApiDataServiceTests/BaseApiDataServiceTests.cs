using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using DFC.App.ExploreCareers.ApiService;
using DFC.App.ExploreCareers.Data.Models;
using FakeItEasy;

namespace DFC.App.ExploreCareers.Services.ApiService.UnitTests.ApiDataServiceTests
{
    public abstract class BaseApiDataServiceTests
    {
        protected BaseApiDataServiceTests()
        {

            FakeHttpRequestSender = A.Fake<IFakeHttpRequestSender>();
            FakeClient = new HttpClient(new FakeHttpMessageHandler(FakeHttpRequestSender));
            FakeClientOptions = new JobCategoryApiClientOptions
            {
                ApiKey = "key",
                BaseAddress = new Uri("https://www.base.com"),
            };
        }

        protected HttpClient FakeClient { get; }

        protected JobCategoryApiClientOptions FakeClientOptions { get; }

        protected IFakeHttpRequestSender FakeHttpRequestSender { get; }

        protected ApiDataService<JobCategoryApiClientOptions> BuildApiDataService()
        {
            return new ApiDataService<JobCategoryApiClientOptions>(FakeClient, FakeClientOptions);
        }
    }
}
