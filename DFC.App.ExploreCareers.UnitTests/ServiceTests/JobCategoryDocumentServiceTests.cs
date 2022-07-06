using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using DFC.App.ExploreCareers.AutoMapperProfiles;
using DFC.App.ExploreCareers.Cosmos;
using DFC.App.ExploreCareers.Data.Models.ContentModels;
using DFC.Compui.Cosmos.Contracts;

using FakeItEasy;

using FluentAssertions;

using Xunit;

namespace DFC.App.ExploreCareers.UnitTests.ServiceTests
{
    public class JobCategoryDocumentServiceTests
    {
        [Fact]
        public async Task GetJobCategoryShouldReturnsResultsOrderedByTitle()
        {
            // Arrange
            var model1 = new JobCategoryContentItemModel()
            {
                Id = Guid.NewGuid(),
                Etag = Guid.NewGuid().ToString(),
                Title = "a-article",
                CanonicalName = "an-article",
                PageLocation = "/an-article"
            };
            var model2 = new JobCategoryContentItemModel()
            {
                Id = Guid.NewGuid(),
                Etag = Guid.NewGuid().ToString(),
                Title = "b-article",
                CanonicalName = "an-article",
                PageLocation = "/an-article"
            };

            var fakeDocumentService = A.Fake<IDocumentService<JobCategoryContentItemModel>>();
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new JobProfileContentItemModelProfile())).CreateMapper();
            A.CallTo(() => fakeDocumentService.GetAllAsync(A<string>.Ignored)).Returns(new List<JobCategoryContentItemModel>() { model2, model1 });

            var service = new JobCategoryDocumentService(fakeDocumentService, mapper);

            // Act
            var result = await service.GetJobCategoriesAsync(null);

            // Assert
            result.Count.Should().Be(2);
            result[0].Name.Should().Be(model1.Title);
            result[1].Name.Should().Be(model2.Title);
        }
    }
}
