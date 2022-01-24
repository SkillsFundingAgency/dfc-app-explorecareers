using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using DFC.App.ExploreCareers.Data.Models.ContentModels;
using DFC.App.ExploreCareers.ViewModels;
using DFC.Compui.Cosmos.Contracts;

namespace DFC.App.ExploreCareers.Cosmos
{
    public class JobCategoryDocumentService : IJobCategoryDocumentService
    {
        private readonly IDocumentService<JobCategoryContentItemModel> documentService;
        private readonly IMapper mapper;

        public JobCategoryDocumentService(
            IDocumentService<JobCategoryContentItemModel> documentService,
            IMapper mapper)
        {
            this.documentService = documentService;
            this.mapper = mapper;
        }

        public async Task<List<JobCategoryViewModel>> GetJobCategoriesAsync(string? partitionKeyValue = null)
        {
            var jobCategoryDocuments = await documentService.GetAllAsync(partitionKeyValue) ?? Enumerable.Empty<JobCategoryContentItemModel>();
            return mapper.Map<List<JobCategoryViewModel>>(jobCategoryDocuments.OrderBy(c => c.Title));
        }
    }
}
