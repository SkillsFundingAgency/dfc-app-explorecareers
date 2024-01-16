using DFC.App.ExploreCareers.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using AutoMapper;
using System.Linq;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using DFC.App.ExploreCareers.AzureSearch;

namespace DFC.App.ExploreCareers.GraphQl
{
    public class GraphQlService : IGraphQlService
    {
        private readonly ISharedContentRedisInterface sharedContentRedisInterface;
        private readonly IMapper mapper;

        public GraphQlService(ISharedContentRedisInterface sharedContentRedisInterface, IMapper mapper)
        {
            this.sharedContentRedisInterface = sharedContentRedisInterface;
            this.mapper = mapper;
        }

        public async Task<List<JobCategoryViewModel>> GetJobCategoriesAsync()
        {
            var response = await sharedContentRedisInterface.GetDataAsync<JobProfileCategoriesResponse>("JobProfiles/Categories")
                ?? new JobProfileCategoriesResponse();
            return mapper.Map<List<JobCategoryViewModel>>(response.JobProfileCategories.OrderBy(c => c.DisplayText));
        }

        public async Task<List<JobProfileIndex>> GetJobProfilesByCategory(string jobProfile)
        {
            var response = await sharedContentRedisInterface.GetDataAsync<JobProfilesResponse>($"JobProfiles/{jobProfile}")
                ?? new JobProfilesResponse();
            //TODO: Check if required
            //return mapper.Map<List<JobProfileIndex>>(response.Items.OrderBy(c => c.Title));
            return new List<JobProfileIndex>();
        }
    }
}
