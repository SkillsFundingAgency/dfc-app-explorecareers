using System;

using DFC.App.ExploreCareers.Data.Models.ContentModels;

using Xunit;

namespace DFC.App.ExploreCareers.Services.CacheContentService.UnitTests.CacheReloadServiceTests
{
    public class ModelValidationTests : BaseCacheReloadServiceTests
    {
        [Fact]
        public void WebhooksServiceTryValidateModelForCreateReturnsSuccess()
        {
            // Arrange
            const bool expectedResponse = true;
            var expectedValidContentItemModel = BuildValidContentItemModel();

            // Act
            var result = CacheReloadService.TryValidateModel(expectedValidContentItemModel);

            // Assert
            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public void WebhooksServiceTryValidateModelForUpdateReturnsFailure()
        {
            // Arrange
            const bool expectedResponse = false;
            var expectedInvalidContentItemModel = new JobCategoryContentItemModel();

            // Act
            var result = CacheReloadService.TryValidateModel(expectedInvalidContentItemModel);

            // Assert
            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public void WebhooksServiceTryValidateModelRaisesExceptionForNullContentItemModel()
        {
            // Arrange
            JobCategoryContentItemModel? nullContentItemModel = null;

            // Act
            var exceptionResult = Assert.Throws<ArgumentNullException>(() => CacheReloadService.TryValidateModel(nullContentItemModel));

            // Assert
            Assert.Equal("Value cannot be null. (Parameter 'contentItemModel')", exceptionResult.Message);
        }
    }
}
