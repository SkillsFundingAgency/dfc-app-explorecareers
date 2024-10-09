using DFC.App.ExploreCareers.ViewModels.JobProfileSector;
using DFC.App.ExploreCareers.ViewModels.SectorLandingPage;
using DfE.NCS.Framework.Core.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.Interfaces
{
    public interface IJobSectorService : ICmsLoadAllQuery<List<JobProfileSector>>, ICmsGetItemByKeyQuery<List<JobProfileSector>>
    {
        Task<List<SectorLandingPageDisplayText>> GetSectorLandingDisplayText(string urlName = "");
    }
}
