using DFC.App.ExploreCareers.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using AutoMapper;
using System.Linq;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using DFC.App.ExploreCareers.AzureSearch;
using Microsoft.Extensions.Configuration;
using Constants = DFC.Common.SharedContent.Pkg.Netcore.Constant.ApplicationKeys;

namespace DFC.App.ExploreCareers.GraphQl
{
    public class GraphQlService : IGraphQlService
    {
        private readonly ISharedContentRedisInterface sharedContentRedisInterface;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private string status;

        public GraphQlService(ISharedContentRedisInterface sharedContentRedisInterface, IMapper mapper, IConfiguration configuration)
        {
            this.sharedContentRedisInterface = sharedContentRedisInterface;
            this.mapper = mapper;
            this.configuration = configuration;
            status = configuration.GetSection("contentMode:contentMode").Get<string>();
        }

        public async Task<List<JobCategoryViewModel>> GetJobCategoriesAsync()
        {
            if (string.IsNullOrEmpty(status))
            {
                status = "PUBLISHED";
            }

            var response = await sharedContentRedisInterface.GetDataAsync<JobProfileCategoriesResponse>(Constants.JobProfileCategories, status)
                ?? new JobProfileCategoriesResponse();
            return mapper.Map<List<JobCategoryViewModel>>(response.JobProfileCategories
                .Where(c => c.DisplayText != null)
                .OrderBy(c => c.DisplayText.Trim().ToString()));
        }

        public async Task<List<JobProfileIndex>> GetJobProfilesByCategoryAsync(string jobProfile)
        {
            if (string.IsNullOrEmpty(status))
            {
                status = "PUBLISHED";
            }

            var response = await sharedContentRedisInterface.GetDataAsync<JobProfilesResponse>($"{Constants.JobProfileSuffix}/{jobProfile}", status)
                ?? new JobProfilesResponse();
            return mapper.Map<List<JobProfileIndex>>(response.JobProfiles.OrderBy(c => c.DisplayText));
        }
    }
}
