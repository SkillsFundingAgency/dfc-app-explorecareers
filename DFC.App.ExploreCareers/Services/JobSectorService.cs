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
using Newtonsoft.Json;

namespace DFC.App.ExploreCareers.Services
{
    public class JobSectorService : CmsRepositoryBase, IJobSectorService
    {
        public const string CacheKeyJobProfileSector = "job-sector";
        public const string CacheKeyLandingSectorPage = "sector-landing-page";

        /// <summary>
        /// Initializes a new instance of the <see cref="JobSectorService"/> class.
        /// </summary>
        /// <param name="querymanager">The querymanager.</param>
        /// <param name="logger">The logger.</param>
        public JobSectorService(ICmsQueryManager querymanager, ILogger<CmsRepositoryBase> logger) : base(querymanager, logger)
        { }
        public async Task<List<JobProfileSector>> GetItemByKey(string key)
        {
            var query = $@"
                query MyQuery {{
                    sectorLandingPage(
                        where: {{
                            contentItemId: ""{key}"",
                            displayText: ""Agriculture, environmental and animal care""
                        }}
                    ) {{
                        displayText
                        modifiedUtc
                        publishedUtc
                        createdUtc
                        render
                        videoType
                        videoTitle
                        videoURL
                        videoDuration
                        videoLinkText
                        videoTranscript
                        withinThisSectorTitle
                        realStoryTitle
                        aboutThisSector
                    }}
                }}";

            // Call GetData to execute the query
            //var result = await _cmsQueryManager.GetData<string>(query, CacheKeyLandingSectorPage);

            var result = await _cmsQueryManager.GetData<dynamic>(query, CacheKeyLandingSectorPage);

            // Handle the response
            if (result.Data == null)
            {
                return null;
            }

            //Deserialize the JSON response into a list of JobProfileSector
           var jobProfileSectors = JsonConvert.DeserializeObject<List<dynamic>>(result.Data);

            return null;
        }

        public async Task<List<JobProfileSector>> LoadAll()
        {
            //string query = @"query MyQuery($first:Int!, $skip: Int!) {
            //      jobProfileSector(
            //        first: $first
            //        skip: $skip
            //      ) {
            //        contentItemId
            //        graphSync {
            //          nodeId
            //        }
            //        displayText
            //        render
            //      }
            //}";


            //string query = $@"query MyQuery($status:Status!, $first:Int!, $skip: Int!) {{
            //      jobProfileSector(
            //        status: {NcsGraphQLTokens.GraphQLStatusToken}
            //        first: {NcsGraphQLTokens.PaginationCountToken}
            //        skip: {NcsGraphQLTokens.SkipCountToken}
            //      ) {{
            //        contentItemId
            //        graphSync {{
            //          nodeId
            //        }}
            //        displayText
            //        render
            //      }}
            //}}";

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

            //string query = $@"query MyQuery {{
            //                          jobProfileSector(status: {NcsGraphQLTokens.GraphQLStatusToken}, first: {NcsGraphQLTokens.PaginationCountToken}, skip: {NcsGraphQLTokens.SkipCountToken}) {{
            //                            contentItemId
            //                            graphSync {{
            //                              nodeId
            //                            }}
            //                            displayText
            //                            render
            //                          }}
            //                          sectorLandingPage {{
            //                            contentItems {{
            //                            contentItemId
            //                            }}
            //                          }}
            //                        }}";

            try
            {
                Func<JobProfileSectorResponse, List<JobProfileSector>> recSelector = col => col.JobProfileSector;

                var response = await _cmsQueryManager.GetDataWithPagination(query, CacheKeyJobProfileSector, recSelector, cacheExpirySeconds: 43200);



                // Ensure response is properly initialized and has non-null Data
                if (response.Data == null)
                {
                    // Handle the null case, e.g., throw an exception, return a default value, etc.
                    throw new InvalidOperationException("Data cannot be null.");
                }

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
