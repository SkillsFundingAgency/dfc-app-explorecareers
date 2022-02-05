using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.BingSpellCheck;

using FakeItEasy;

using FluentAssertions;

using Microsoft.Extensions.Logging;

using Xunit;

namespace DFC.App.ExploreCareers.UnitTests.ServiceTests
{
    public class SpellCheckServiceTests
    {
        private readonly string testFilePath;
        private readonly ILogger<SpellCheckService> fakeLogger = A.Fake<ILogger<SpellCheckService>>();

        public SpellCheckServiceTests()
        {
            testFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory!, "TestData/spell-check-response.json");
        }

        [Fact]
        public async Task CheckSpellingShouldNotCorrectForEmtpySearchTerm()
        {
            // Arrange
            var service = new SpellCheckService(fakeLogger, new HttpClient());

            // Act
            var response = await service.CheckSpellingAsync(string.Empty);

            // Assert
            response.HasCorrected.Should().BeFalse();
        }

        [Fact]
        public async Task CheckSpellingShouldReturnCorrectedTerm()
        {
            // Arrange
            using var stream = File.OpenRead(testFilePath);
            var handler = FakeHttpMessageHandler.Create(stream, System.Net.HttpStatusCode.OK);
            var client = new HttpClient(handler) { BaseAddress = new Uri("https://sample.com/") };
            var service = new SpellCheckService(fakeLogger, client);

            // Act
            var response = await service.CheckSpellingAsync("hollo");

            // Assert
            response.HasCorrected.Should().BeTrue();
            response.CorrectedTerm.Should().Be("Hello");
        }

        [Fact]
        public async Task CheckSpellingShouldNotCorrectWhenNoSuggestionsReturned()
        {
            // Arrange
            var fileContent = "{\"_type\": \"SpellCheck\", \"flaggedTokens\": [] }";
            var handler = FakeHttpMessageHandler.Create(fileContent, System.Net.HttpStatusCode.OK);
            var client = new HttpClient(handler) { BaseAddress = new Uri("https://sample.com/") };
            var service = new SpellCheckService(fakeLogger, client);

            // Act
            var response = await service.CheckSpellingAsync("hello");

            // Assert
            response.HasCorrected.Should().BeFalse();
        }

        [Fact]
        public async Task CheckSpellingShouldNotCorrectWhenBingApiCallFailed()
        {
            // Arrange
            using var handler = FakeHttpMessageHandler.Create(string.Empty, System.Net.HttpStatusCode.BadRequest);
            var client = new HttpClient(handler) { BaseAddress = new Uri("https://sample.com/") };
            var service = new SpellCheckService(fakeLogger, client);

            // Act
            var response = await service.CheckSpellingAsync("hollo");

            // Assert
            response.HasCorrected.Should().BeFalse();
        }

        [Fact]
        public async Task CheckSpellingShouldNotCorrectOnException()
        {
            // Arrange
            using var handler = FakeHttpMessageHandler.Create(string.Empty, System.Net.HttpStatusCode.OK);
            var client = new HttpClient(handler);
            var service = new SpellCheckService(fakeLogger, client);

            // Act
            var response = await service.CheckSpellingAsync("hollo");

            // Assert
            response.HasCorrected.Should().BeFalse();
        }
    }
}
