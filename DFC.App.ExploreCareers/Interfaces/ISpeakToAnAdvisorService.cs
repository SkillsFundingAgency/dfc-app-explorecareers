using DFC.App.ExploreCareers.ViewModels;
using DFC.App.ExploreCareers.ViewModels.AllCareersJobProfile;
using DfE.NCS.Framework.Core.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.Interfaces
{
    public interface ISpeakToAnAdvisorService : ICmsGetItemByKeyQuery<List<SharedContent>>
    {
       
    }
}
