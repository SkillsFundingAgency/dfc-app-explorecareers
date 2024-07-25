using DFC.App.ExploreCareers.ViewModels.JobProfileSector;
using DfE.NCS.Framework.Core.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.Interfaces
{
    public interface IJobSectorService : ICmsLoadAllQuery<List<JobProfileSector>>, ICmsGetItemByKeyQuery<List<JobProfileSector>>
    {
    }
}
