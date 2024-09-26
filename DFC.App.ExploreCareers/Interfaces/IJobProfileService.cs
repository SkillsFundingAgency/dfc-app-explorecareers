using DFC.App.ExploreCareers.ViewModels.AllCareersJobProfile;
using DFC.App.ExploreCareers.ViewModels.JobProfile;
using DfE.NCS.Framework.Core.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DFC.App.ExploreCareers.Interfaces
{
    public interface IJobProfileService : ICmsGetItemByKeyQuery<List<JobProfile>>
    {
        Task<List<AllCareersJobProfile>> GetAllJobProfile(List<string>? selectedCategoryIds = null);

        Task<List<JobProfileCategoryContentItem>> GetAllCategories ();
    }
}
