using DFC.App.ExploreCareers.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.GraphQl
{
    public interface IGraphQlService
    {
        Task<List<JobCategoryViewModel>> GetJobCategoriesAsync();
    }
}
