using System.Collections.Generic;
using System.Threading.Tasks;
using DFC.App.ExploreCareers.Data.Models;
using FakeItEasy;
using Xunit;

namespace DFC.App.ExploreCareers.UnitTests.ControllerTests.ExploreCareersControllerTests
{
    public class ExploreCareersControllerTests : BaseExploreCareersControllerTests
    {
        [Fact]
        public async Task ExploreCareersBodyReturnsHtml()
        {
            var controller = BuildExploreCareersController();

            A.CallTo(() => FakeDocumentService.GetAllAsync(null)).Returns(new List<JobCategory>());

            await controller.Body().ConfigureAwait(false);

            A.CallTo(() => FakeDocumentService.GetAllAsync(null)).MustHaveHappenedOnceExactly();

            controller.Dispose();
        }
    }
}
