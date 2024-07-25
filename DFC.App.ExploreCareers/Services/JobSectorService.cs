using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using DFC.App.ExploreCareers.Interfaces;
using DFC.App.ExploreCareers.ViewModels.JobProfileSector;
using DfE.NCS.Framework.Core.Constants;
using DfE.NCS.Framework.Core.Repository;
using DfE.NCS.Framework.Core.Repository.Interface;
using DfE.NCS.Framework.SharedContent.Cms;
using DfE.NCS.Framework.SharedContent.Cms.Model;
using Microsoft.Extensions.Logging;

namespace DFC.App.ExploreCareers.Services
{
    public class JobSectorService : CmsRepositoryBase, IJobSectorService
    {
        public const string CacheKeyJobProfileSector = "job-sector";

        /// <summary>
        /// Initializes a new instance of the <see cref="JobSectorService"/> class.
        /// </summary>
        /// <param name="querymanager">The querymanager.</param>
        /// <param name="logger">The logger.</param>
        public JobSectorService(ICmsQueryManager querymanager, ILogger<CmsRepositoryBase> logger) : base(querymanager, logger)
        {
        }

        public Task<List<JobProfileSector>> GetItemByKey(string key)
        {
            throw new NotImplementedException();
        }

        public async Task<List<JobProfileSector>> LoadAll()
        {
            string query = $@"query MyQuery {{
                                      jobProfileSector(status: {NcsGraphQLTokens.GraphQLStatusToken}, first: {NcsGraphQLTokens.PaginationCountToken}, skip: {NcsGraphQLTokens.SkipCountToken}) {{
                                        contentItemId
                                        graphSync {{
                                          nodeId
                                        }}
                                        displayText
                                        render
                                      }}
                                    }}";

            try
            {
                Func<JobProfileSectorResponse, List<JobProfileSector>> recSelector = col => col.JobProfileSector;
                var response = await _cmsQueryManager.GetDataWithPagination(query, CacheKeyJobProfileSector, recSelector);
                return response.Data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
