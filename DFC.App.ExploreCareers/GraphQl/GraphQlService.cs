using DFC.App.ExploreCareers.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using AutoMapper;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles.JobProfileCategory;
using System.Linq;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using DFC.App.ExploreCareers.Data.Models.ContentModels;
using DFC.Common.SharedContent.Pkg.Netcore.Repo;
using NHibernate.Engine;

namespace DFC.App.ExploreCareers.GraphQl
{
    public class GraphQlService : IGraphQlService
    {
        private readonly ISharedContentRedisInterface sharedContentRedisInterface;
        private readonly IMapper mapper;

        public GraphQlService(IMapper mapper, ISharedContentRedisInterface sharedContentRedisInterface)
        {
            this.mapper = mapper;
            this.sharedContentRedisInterface = sharedContentRedisInterface;
        }

        public async Task<List<JobCategoryViewModel>> GetJobCategoriesAsync()
        {
            var response = await sharedContentRedisInterface.GetDataAsync<JobProfileCategoriesResponse>("JobProfiles/Categories")
                ?? new JobProfileCategoriesResponse();
            return mapper.Map<List<JobCategoryViewModel>>(response.JobProfileCategories.OrderBy(c => c.DisplayText));
        }
    }
}
