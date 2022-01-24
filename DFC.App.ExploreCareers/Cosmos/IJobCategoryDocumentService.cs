using System.Collections.Generic;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.ViewModels;

namespace DFC.App.ExploreCareers.Cosmos
{
    public interface IJobCategoryDocumentService
    {
        Task<List<JobCategoryViewModel>> GetJobCategoriesAsync(string? partitionKeyValue = null);
    }
}