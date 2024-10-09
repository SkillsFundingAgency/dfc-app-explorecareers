using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading.Tasks;
using Azure.Core;
using DFC.App.ExploreCareers.Interfaces;
using DFC.App.ExploreCareers.ViewModels.JobProfileSector;
using DFC.App.ExploreCareers.ViewModels.SectorLandingPage;
using DfE.NCS.Framework.Core.Constants;
using DfE.NCS.Framework.Core.Repository;
using DfE.NCS.Framework.Core.Repository.Interface;
using DfE.NCS.Framework.SharedContent.Cms;
using DfE.NCS.Framework.SharedContent.Cms.Model;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
        {}

        public async Task<List<JobProfileSector>> GetItemByKey(string key)
        {
            string query = $@"
            query MyQuery {{
                sectorLandingPage(
                where: {{pageLocation: {{urlName: ""{key}""}}}}
                status: {NcsGraphQLTokens.GraphQLStatusToken}, first: {NcsGraphQLTokens.PaginationCountToken}, skip: {NcsGraphQLTokens.SkipCountToken}
                ) {{
                contentItemId
                displayText
                heroBanner {{
                    html
                }}
                description {{
                    html
                }}
                videoImage {{
                    paths
                    urls
                }}
                videoDuration
                videoTranscript
                profileDescription {{
                    html
                }}
                jobProfile {{
                    contentItems {{
                    displayText
                    ... on JobProfile {{
                        modifiedUtc
                        overview
                        salarystarterperyear
                        salaryexperiencedperyear
                        pageLocation {{
                        fullUrl
                        }}
                    }}
                    }}
                }}
                jobDescription {{
                    html
                }}
                furtherInspiration {{
                    html
                }}
                jobProfileInspiration {{
                    contentItems {{
                    displayText
                    ... on JobProfile {{
                        displayText
                        overview
                        salarystarterperyear
                        salaryexperiencedperyear
                        pageLocation {{
                        fullUrl
                        }}
                    }}
                    }}
                }}
                jobProfileInspirationDescription {{
                    html
                }}
                realStoryDescription {{
                    html
                }}
                realStoryImage {{
                    paths
                    urls
                    mediaText
                }}
                realStoryImageDescription {{
                    html
                }}
                exploreAllSectors {{
                    html
                }}
                }}
            }}";

            Func<SectorLandingPageResponse, List<ViewModels.SectorLandingPage.SectorLandingPage>> recSelector = col => col.SectorLandingPage;

            var result = await _cmsQueryManager.GetDataWithPagination(query, cacheKey: key, recSelector);

            // Handle the response
            if (result?.Data == null)
            {
                return null;
            }

            var jobProfileSectors = new List<JobProfileSector>();

            foreach (var sectorLandingPage in result.Data)
            {
                var jobProfileSector = new JobProfileSector
                {
                    SectorLandingPageSearchResults = result?.Data
                };

                jobProfileSectors.Add(jobProfileSector);
            }

            return jobProfileSectors;

        }

        public async Task<List<SectorLandingPageDisplayText>> GetSectorLandingDisplayText(string urlName = "")
        {
            string query = $@"
            query MyQuery {{
                sectorLandingPage(
                where: {{pageLocation: {{urlName: ""{urlName}""}}}}
                status: {NcsGraphQLTokens.GraphQLStatusToken}, first: {NcsGraphQLTokens.PaginationCountToken}, skip: {NcsGraphQLTokens.SkipCountToken}
                ) {{
                contentItemId
                displayText
                }}
            }}";


            Func<SectorLandingPageDisplayTextResponse, List<ViewModels.SectorLandingPage.SectorLandingPageDisplayText>> recSelector = col => col.SectorLandingPage;

            var result = await _cmsQueryManager.GetDataWithPagination(query, cacheKey: urlName, recSelector);


            // Handle the response
            if (result?.Data == null)
            {
                return null;
            }

            return result.Data;
        }

        public async Task<List<JobProfileSector>> LoadAll()
        {

            string query = $@"query MyQuery {{
                                      jobProfileSector(
                                        status: {NcsGraphQLTokens.GraphQLStatusToken}, 
                                        first: {NcsGraphQLTokens.PaginationCountToken}, 
                                        skip: {NcsGraphQLTokens.SkipCountToken},
                                        orderBy: {{displayText: ASC}}) {{
                                        contentItemId
                                        graphSync {{
                                          nodeId
                                        }}
                                        displayText
                                        description
                                        image {{
                                            urls
                                        }}
                                        render
                                        sectorLandingPage {{
                                          contentItems {{
                                            contentItemId
                                            ... on SectorLandingPage {{
                                              displayText
                                              pageLocation {{
                                                fullUrl
                                                urlName
                                              }}
                                            }}
                                          }}
                                        }}
                                      }}
                                    }}";

            try
            {
                Func<JobProfileSectorResponse, List<JobProfileSector>> recSelector = col => col.JobProfileSector;

                var response = await _cmsQueryManager.GetDataWithPagination(query, cacheKey: Guid.NewGuid().ToString(), recSelector);
                //var response = await _cmsQueryManager.GetDataWithPagination(query, CacheKeyJobProfileSector, recSelector);

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
