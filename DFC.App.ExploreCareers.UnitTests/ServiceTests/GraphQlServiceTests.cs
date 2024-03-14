using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using DFC.App.ExploreCareers.AutoMapperProfiles;
using DFC.App.ExploreCareers.GraphQl;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;

using FakeItEasy;

using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace DFC.App.ExploreCareers.UnitTests.ServiceTests
{
    public class GraphQlServiceTests
    {
        [Fact]
        public async Task GetJobCategoryShouldReturnsResultsOrderedByTitle()
        {
            var jobCategory1 = new JobProfileCategory
            {
                DisplayText = "a-article",
                PageLocation = new PageLocation
                {
                    FullUrl = "an-article",
                    UrlName = "/an-article"
                }
            };
            var jobCategory2 = new JobProfileCategory
            {
                DisplayText = "b-article",
                PageLocation = new PageLocation
                {
                    FullUrl = "an-article",
                    UrlName = "/an-article"
                }
            };

            var jobProfileCategories = new JobProfileCategory[] { jobCategory2, jobCategory1 };

            var jobProfileCategoriesResponse = new JobProfileCategoriesResponse
            {
                JobProfileCategories = jobProfileCategories
            };

            var fakeSharedContentRedisInterface = A.Fake<ISharedContentRedisInterface>();
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new JobProfileContentItemModelProfile())).CreateMapper();
            var fakeIConfiguration = A.Fake<IConfiguration>();
            A.CallTo(() => fakeSharedContentRedisInterface.GetDataAsync<JobProfileCategoriesResponse>(A<string>.Ignored, "PUBLISHED")).Returns(jobProfileCategoriesResponse);

            var service = new GraphQlService(fakeSharedContentRedisInterface, mapper, fakeIConfiguration);

            // Act
            var result = await service.GetJobCategoriesAsync();

            // Assert
            result.Count.Should().Be(2);
            result[0].Name.Should().Be(jobCategory1.DisplayText);
            result[1].Name.Should().Be(jobCategory2.DisplayText);
        }

        [Fact]
        public async Task GetJobProfilesByCategoryShouldReturnsResultsOrderedByTitle()
        {
            var jobCategory = "test";
            var jobProfile1 = new JobProfile
            {
                DisplayText = "a-article",
                AlternativeTitle = "a-article",
                Overview = "An article",
            };
            var jobProfile2 = new JobProfile
            {
                DisplayText = "a-article",
                AlternativeTitle = "a-article",
                Overview = "An article",
            };

            var jobProfiles = new List<JobProfile> { jobProfile2, jobProfile1 };

            var jobProfilesResponse = new JobProfilesResponse
            {
                JobProfiles = jobProfiles
            };

            var fakeSharedContentRedisInterface = A.Fake<ISharedContentRedisInterface>();
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new JobProfileContentItemModelProfile())).CreateMapper();
            var fakeIConfiguration = A.Fake<IConfiguration>();
            A.CallTo(() => fakeSharedContentRedisInterface.GetDataAsync<JobProfilesResponse>(A<string>.Ignored, "PUBLISHED")).Returns(jobProfilesResponse);

            var service = new GraphQlService(fakeSharedContentRedisInterface, mapper, fakeIConfiguration);

            // Act
            var result = await service.GetJobProfilesByCategoryAsync(jobCategory);

            // Assert
            result.Count.Should().Be(2);
            result[0].Title.Should().Be(jobProfile1.DisplayText);
            result[1].Title.Should().Be(jobProfile2.DisplayText);
        }
    }
}
