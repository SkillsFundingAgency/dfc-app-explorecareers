using DFC.App.ExploreCareers.Interfaces;
using DFC.App.ExploreCareers.ViewModels;
using DFC.App.ExploreCareers.ViewModels.AllCareersJobProfile;
using DfE.NCS.Framework.Core.Constants;
using DfE.NCS.Framework.Core.Repository;
using DfE.NCS.Framework.Core.Repository.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.Services
{
    public class SpeakToAnAdvisorService : CmsRepositoryBase, ISpeakToAnAdvisorService
    {
        public const string CacheKeyAllCategories = "ExploreCareer/speaktoanadvisor/PUBLISHED";
        public SpeakToAnAdvisorService(ICmsQueryManager querymanager, ILogger<CmsRepositoryBase> logger) : base(querymanager, logger)
        {
        }

        public async Task<List<SharedContent>> GetItemByKey(string key)
        {


            var getSpeakToAnAdvisors = $@"
                 query MyQuery {{
                      sharedContent(
                        where: {{displayText_contains: ""{key}""}}
                        status: {NcsGraphQLTokens.GraphQLStatusToken}, first: {NcsGraphQLTokens.PaginationCountToken}, skip: {NcsGraphQLTokens.SkipCountToken}
                        ) {{
                        displayText
                        content {{
                          html
                        }}
                      }}
                    }}
                ";


            Func<SpeakToAndvisor, List<SharedContent>> speakToAnAdvisors = col => col.SharedContent;

            var response = await _cmsQueryManager.GetDataWithPagination(getSpeakToAnAdvisors, CacheKeyAllCategories, speakToAnAdvisors);

            if (response.Data == null)
            {
                // Handle the null case, e.g., throw an exception, return a default value, etc.
                throw new InvalidOperationException("Data cannot be null.");
            }

            if (response.Data == null)
            {
                return null;
            }

            return response.Data;

        }
    }
}
