using System.Collections.Generic;
using System.Threading.Tasks;
using DFC.App.ExploreCareers.Data.Contracts;
using DFC.App.ExploreCareers.Data.Models;

namespace DFC.App.ExploreCareers.Services.JobCategoriesApiProcessorService
{
    public class JobCategoriesApiService : IJobCategoriesApiService
    {
        public Task<IList<JobCategory>> GetJobCategories()
        {
            throw new System.NotImplementedException();
        }
    }
}
