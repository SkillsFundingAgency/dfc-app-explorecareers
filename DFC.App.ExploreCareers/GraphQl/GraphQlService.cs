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
            var response = await sharedContentRedisInterface.GetDataAsync<JobProfileCategoriesResponse>("JobProfiles/Categories", "PUBLISHED")
                ?? new JobProfileCategoriesResponse();
            return mapper.Map<List<JobCategoryViewModel>>(response.JobProfileCategories
                .Where(c => c.DisplayText != null)
                .OrderBy(c => c.DisplayText.Trim().ToString()));
        }

        public async Task<List<JobProfileIndex>> GetJobProfilesByCategoryAsync(string jobProfile)
        {
            var response = await sharedContentRedisInterface.GetDataAsync<JobProfilesResponse>($"JobProfiles/{jobProfile}", "PUBLISHED")
                ?? new JobProfilesResponse();
            return mapper.Map<List<JobProfileIndex>>(response.JobProfiles.OrderBy(c => c.DisplayText));
        }
    }
}
