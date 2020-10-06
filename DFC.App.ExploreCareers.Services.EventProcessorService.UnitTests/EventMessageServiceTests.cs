using DFC.App.ExploreCareers.Data.Models;
using DFC.Compui.Cosmos.Contracts;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace DFC.App.ExploreCareers.Services.EventProcessorService.UnitTests
{
    [Trait("Category", "Event Message Service Unit Tests")]
    public class EventMessageServiceTests
    {
        private readonly ILogger<EventMessageService<JobCategory>> fakeLogger = A.Fake<ILogger<EventMessageService<JobCategory>>>();
        private readonly IDocumentService<JobCategory> fakeDocumentService = A.Fake<IDocumentService<JobCategory>>();

        [Fact]
        public async Task EventMessageServiceGetAllCachedCanonicalNamesReturnsSuccess()
        {
            // arrange
            var expectedResult = A.CollectionOfFake<JobCategory>(2);

            A.CallTo(() => fakeDocumentService.GetAllAsync(null)).Returns(expectedResult);

            var eventMessageService = new EventMessageService<JobCategory>(fakeLogger, fakeDocumentService);

            // act
            var result = await eventMessageService.GetAllCachedCanonicalNamesAsync().ConfigureAwait(false);

            // assert
            A.CallTo(() => fakeDocumentService.GetAllAsync(null)).MustHaveHappenedOnceExactly();
            A.Equals(result, expectedResult);
        }

        [Fact]
        public async Task EventMessageServiceCreateAsyncReturnsSuccess()
        {
            // arrange
            JobCategory? existingJobCategoryModel = null;
            var jobCategoryModel = A.Fake<JobCategory>();
            var expectedResult = HttpStatusCode.OK;

            A.CallTo(() => fakeDocumentService.GetByIdAsync(A<Guid>.Ignored, null)).Returns(existingJobCategoryModel);
            A.CallTo(() => fakeDocumentService.UpsertAsync(A<JobCategory>.Ignored)).Returns(expectedResult);

            var eventMessageService = new EventMessageService<JobCategory>(fakeLogger, fakeDocumentService);

            // act
            var result = await eventMessageService.CreateOrUpdateAsync(jobCategoryModel).ConfigureAwait(false);

            // assert
            A.CallTo(() => fakeDocumentService.GetByIdAsync(A<Guid>.Ignored, null)).MustHaveHappenedOnceExactly();
            A.CallTo(() => fakeDocumentService.UpsertAsync(A<JobCategory>.Ignored)).MustHaveHappenedOnceExactly();
            A.Equals(result, expectedResult);
        }

        [Fact]
        public async Task EventMessageServiceCreateAsyncReturnsBadRequestWhenNullSupplied()
        {
            // arrange
            JobCategory? jobCategory = null;
            var expectedResult = HttpStatusCode.BadRequest;

            var eventMessageService = new EventMessageService<JobCategory>(fakeLogger, fakeDocumentService);

            // act
            var result = await eventMessageService.CreateOrUpdateAsync(jobCategory).ConfigureAwait(false);

            // assert
            A.CallTo(() => fakeDocumentService.GetByIdAsync(A<Guid>.Ignored, null)).MustNotHaveHappened();
            A.CallTo(() => fakeDocumentService.UpsertAsync(A<JobCategory>.Ignored)).MustNotHaveHappened();
            A.Equals(result, expectedResult);
        }

        [Fact]
        public async Task EventMessageServiceCreateAsyncReturnsAlreadyReportedWhenAlreadyExists()
        {
            // arrange
            var existingJobCategoryModel = A.Fake<JobCategory>();
            var jobCategoryModel = A.Fake<JobCategory>();
            var expectedResult = HttpStatusCode.AlreadyReported;

            A.CallTo(() => fakeDocumentService.GetByIdAsync(A<Guid>.Ignored, null)).Returns(existingJobCategoryModel);

            var eventMessageService = new EventMessageService<JobCategory>(fakeLogger, fakeDocumentService);

            // act
            var result = await eventMessageService.CreateOrUpdateAsync(jobCategoryModel).ConfigureAwait(false);

            // assert
            A.CallTo(() => fakeDocumentService.GetByIdAsync(A<Guid>.Ignored, null)).MustHaveHappenedOnceExactly();
            A.CallTo(() => fakeDocumentService.UpsertAsync(A<JobCategory>.Ignored)).MustHaveHappenedOnceExactly();
            A.Equals(result, expectedResult);
        }
        
        [Fact]
        public async Task EventMessageServiceDeleteAsyncReturnsSuccess()
        {
            // arrange
            var expectedResult = HttpStatusCode.OK;

            A.CallTo(() => fakeDocumentService.DeleteAsync(A<Guid>.Ignored)).Returns(true);

            var eventMessageService = new EventMessageService<JobCategory>(fakeLogger, fakeDocumentService);

            // act
            var result = await eventMessageService.DeleteAsync(Guid.NewGuid()).ConfigureAwait(false);

            // assert
            A.CallTo(() => fakeDocumentService.DeleteAsync(A<Guid>.Ignored)).MustHaveHappenedOnceExactly();
            A.Equals(result, expectedResult);
        }

        [Fact]
        public async Task EventMessageServiceDeleteAsyncReturnsNotFound()
        {
            // arrange
            var expectedResult = HttpStatusCode.NotFound;

            A.CallTo(() => fakeDocumentService.DeleteAsync(A<Guid>.Ignored)).Returns(false);

            var eventMessageService = new EventMessageService<JobCategory>(fakeLogger, fakeDocumentService);

            // act
            var result = await eventMessageService.DeleteAsync(Guid.NewGuid()).ConfigureAwait(false);

            // assert
            A.CallTo(() => fakeDocumentService.DeleteAsync(A<Guid>.Ignored)).MustHaveHappenedOnceExactly();
            A.Equals(result, expectedResult);
        }
    }
}
