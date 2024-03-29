﻿using System;
using System.Net;
using System.Threading.Tasks;

using FakeItEasy;

using Xunit;

namespace DFC.App.ExploreCareers.Services.CacheContentService.UnitTests.WebhooksServiceTests
{
    [Trait("Category", "Webhooks Service DeleteContentAsync Unit Tests")]
    public class DeleteContentAsyncTests : BaseWebhooksServiceTests
    {
        [Fact]
        public async Task WebhooksServiceDeleteContentAsyncForCreateReturnsSuccess()
        {
            // Arrange
            const bool expectedResponse = true;
            const HttpStatusCode expectedResult = HttpStatusCode.OK;
            var service = BuildWebhooksService();

            A.CallTo(() => FakeSharedContentItemDocumentService.DeleteAsync(A<Guid>.Ignored)).Returns(expectedResponse);

            // Act
            var result = await service.DeleteContentAsync(ContentIdForDelete);

            // Assert
            A.CallTo(() => FakeSharedContentItemDocumentService.DeleteAsync(A<Guid>.Ignored)).MustHaveHappenedOnceExactly();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task WebhooksServiceDeleteContentAsyncForCreateReturnsNoContent()
        {
            // Arrange
            const bool expectedResponse = false;
            const HttpStatusCode expectedResult = HttpStatusCode.NoContent;
            var service = BuildWebhooksService();

            A.CallTo(() => FakeSharedContentItemDocumentService.DeleteAsync(A<Guid>.Ignored)).Returns(expectedResponse);

            // Act
            var result = await service.DeleteContentAsync(ContentIdForDelete);

            // Assert
            A.CallTo(() => FakeSharedContentItemDocumentService.DeleteAsync(A<Guid>.Ignored)).MustHaveHappenedOnceExactly();

            Assert.Equal(expectedResult, result);
        }
    }
}
