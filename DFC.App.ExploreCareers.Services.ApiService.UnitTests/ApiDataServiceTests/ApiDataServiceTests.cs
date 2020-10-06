using FakeItEasy;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DFC.App.ExploreCareers.Data.Models;
using Newtonsoft.Json;
using Polly.CircuitBreaker;
using Xunit;

namespace DFC.App.ExploreCareers.Services.ApiService.UnitTests.ApiDataServiceTests
{
    public class ApiDataServiceTests : BaseApiDataServiceTests
    {

        [Fact]
        public async Task GetAllReturnsEmptyStringIfResponseIsNotOk()
        {
            var service = BuildApiDataService();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(""),
            };

            A.CallTo(() => FakeHttpRequestSender.Send(A<HttpRequestMessage>.Ignored)).Returns(httpResponse);

            var result = await service.GetAllAsync().ConfigureAwait(false);

            A.CallTo(() => FakeHttpRequestSender.Send(A<HttpRequestMessage>.Ignored)).MustHaveHappenedOnceExactly();

            Assert.Equal(string.Empty, result);

            httpResponse.Dispose();
        }

        [Fact]
        public async Task GetAllReturnsEmptyStringIfBrokenCircuitExceptionIfThrown()
        {
            var service = BuildApiDataService();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(""),
            };

            A.CallTo(() => FakeHttpRequestSender.Send(A<HttpRequestMessage>.Ignored)).Throws(new BrokenCircuitException());

            var result = await service.GetAllAsync().ConfigureAwait(false);

            A.CallTo(() => FakeHttpRequestSender.Send(A<HttpRequestMessage>.Ignored)).MustHaveHappenedOnceExactly();

            Assert.Equal(string.Empty, result);

            httpResponse.Dispose();
        }

        [Fact]
        public async Task GetAllReturnsCorrectString()
        {
            var service = BuildApiDataService();

            var expected = "expectedResponseString";

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(expected),
            };

            A.CallTo(() => FakeHttpRequestSender.Send(A<HttpRequestMessage>.Ignored)).Returns(httpResponse);

            var result = await service.GetAllAsync().ConfigureAwait(false);

            A.CallTo(() => FakeHttpRequestSender.Send(A<HttpRequestMessage>.Ignored)).MustHaveHappenedOnceExactly();

            Assert.Equal(expected, result);

            httpResponse.Dispose();
        }

        [Fact]
        public async Task GetAllReturnsCorrectObjectType()
        {
            var service = BuildApiDataService();

            var expected = "html";

            var jobCategory = new JobCategory()
            {
                Html = expected,
            };

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(jobCategory)),
            };

            A.CallTo(() => FakeHttpRequestSender.Send(A<HttpRequestMessage>.Ignored)).Returns(httpResponse);

            var result = await service.GetAllAsync<JobCategory>().ConfigureAwait(false);

            A.CallTo(() => FakeHttpRequestSender.Send(A<HttpRequestMessage>.Ignored)).MustHaveHappenedOnceExactly();

            Assert.Equal(expected, result.Html);

            httpResponse.Dispose();
        }
    }
}
