using System.Collections.Generic;
using System.Threading.Tasks;
using DFC.App.ExploreCareers.Data.Models;

namespace DFC.App.ExploreCareers.Data.Contracts
{
    public interface IJobCategoriesApiService
    {
        Task<IList<JobCategory>> GetJobCategories();
    }
}
