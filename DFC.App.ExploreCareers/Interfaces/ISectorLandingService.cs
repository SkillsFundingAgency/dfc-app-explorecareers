using DFC.App.ExploreCareers.ViewModels.JobProfileSector;
using DFC.App.ExploreCareers.ViewModels.SectorLandingPage;
using DfE.NCS.Framework.Core.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.Interfaces
{
    public interface ISectorLandingService : ICmsLoadAllQuery<List<SectorLandingPage>>, ICmsGetItemByKeyQuery<List<SectorLandingPage>>
    {
    }
}
