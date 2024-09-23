using DFC.App.ExploreCareers.ViewModels.JobProfile;
using DFC.App.ExploreCareers.ViewModels.JobProfileSector;
using DfE.NCS.Framework.Core.Repository.Interface;
using System.Collections.Generic;

namespace DFC.App.ExploreCareers.Interfaces
{
    public interface IJobProfileService : ICmsGetItemByKeyQuery<List<JobProfile>>
    {
    }
}
