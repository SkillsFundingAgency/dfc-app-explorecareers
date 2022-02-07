using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.UnitTests
{
    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        private readonly HttpResponseMessage response;

        public FakeHttpMessageHandler(HttpResponseMessage response)
        {
            this.response = response;
        }

        public static HttpMessageHandler Create(Stream stream, HttpStatusCode httpStatusCode)
        {
            var messageHandler = new FakeHttpMessageHandler(new HttpResponseMessage()
            {
                StatusCode = httpStatusCode,
                Content = new StreamContent(stream)
            });

            return messageHandler;
        }

        public static HttpMessageHandler Create(string content, HttpStatusCode httpStatusCode)
        {
            var memStream = new MemoryStream();

            var sw = new StreamWriter(memStream);
            sw.Write(content);
            sw.Flush();
            memStream.Position = 0;

            var messageHandler = new FakeHttpMessageHandler(new HttpResponseMessage()
            {
                StatusCode = httpStatusCode,
                Content = new StreamContent(memStream)
            });

            return messageHandler;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<HttpResponseMessage>();

            tcs.SetResult(response);

            return tcs.Task;
        }
    }
}
