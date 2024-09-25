using DFC.App.ExploreCareers.Interfaces;
using DFC.App.ExploreCareers.ViewModels.JobProfile;
using DFC.App.ExploreCareers.ViewModels.JobProfile.SectorLandingPage;
using DfE.NCS.Framework.Core.Constants;
using DfE.NCS.Framework.Core.Repository;
using DfE.NCS.Framework.Core.Repository.Interface;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobProfile = DFC.App.ExploreCareers.ViewModels.JobProfile.JobProfile;
using JSLUrl = DFC.App.ExploreCareers.ViewModels.JobProfile.SectorLandingPage;

namespace DFC.App.ExploreCareers.Services
{
    public class JobProfileService : CmsRepositoryBase, IJobProfileService
    {
        public JobProfileService(ICmsQueryManager querymanager, ILogger<CmsRepositoryBase> logger) : base(querymanager, logger)
        {
        }

        public async Task<List<ViewModels.JobProfile.JobProfile>> GetItemByKey(string key)
        {
            // Construct the GraphQL query dynamically
            var getQueryForJobProfileList = $@"
                    query MyQuery {{
                        sectorLandingPage(
                            where: {{contentItemId: ""{key}""}}, 
                            status: {NcsGraphQLTokens.GraphQLStatusToken}, first: {NcsGraphQLTokens.PaginationCountToken}, skip: {NcsGraphQLTokens.SkipCountToken}
                        ) {{
                            displayText
                            jobProfile {{
                                contentItems {{
                                    displayText
                                    contentItemId
                                }}
                            }}
                        }}
                    }}";

            Func<SectorLandingPageResponse, List<SectorLandingPage>> recSelector = col =>
            {
                return col?.SectorLandingPage ?? new List<SectorLandingPage>();
            };

            var response = await _cmsQueryManager.GetDataWithPagination(getQueryForJobProfileList, cacheKey: key, recSelector);

            if (response.Data == null)
            {
                Console.WriteLine("Response Data is null.");
                return null;
            }

            var displayTexts = new List<string>();
            var contentItemIds = new List<string>();

            foreach (var sectorLandingPage in response.Data)
            {
                if (sectorLandingPage?.JobProfile?.ContentItems != null)
                {
                    foreach (var item in sectorLandingPage.JobProfile.ContentItems)
                    {
                        displayTexts.Add(item.DisplayText);
                        contentItemIds.Add(item.ContentItemId);
                    }
                }
            }

            var formattedDisplayTexts = string.Join(", ", displayTexts.Select(text => $"\"{text}\""));

            var formattedcontentItemIds = string.Join(", ", contentItemIds.Select(id => $"\"{id}\""));

            //// Construct the GraphQL query contentItemId_in
            //var jobProfileQuery = $@"
            //    query MyQuery {{
            //        jobProfile(
            //        where: {{contentItemId_in: [{formattedcontentItemIds}]}},
            //        status: {NcsGraphQLTokens.GraphQLStatusToken}, first: {NcsGraphQLTokens.PaginationCountToken}, skip: {NcsGraphQLTokens.SkipCountToken}
            //            ) 
            //        {{
            //        displayText
            //        contentItemId
            //        overview
            //        salarystarterperyear
            //        salaryexperiencedperyear
            //        jobProfileSector {{
            //            contentItems {{
            //            displayText
            //            }}
            //        }}
            //        }}
            //    }}";


            // Construct the GraphQL query contentItemId_in
            var jobProfileQuery = $@"
                query MyQuery {{
                    jobProfile(
                    where: {{displayText_in: [{formattedDisplayTexts}]}},
                    status: {NcsGraphQLTokens.GraphQLStatusToken}, first: {NcsGraphQLTokens.PaginationCountToken}, skip: {NcsGraphQLTokens.SkipCountToken}
                        ) 
                    {{
                    displayText
                    alternativeTitle
                    contentItemId
                    overview
                    salarystarterperyear
                    salaryexperiencedperyear
                    pageLocation {{
                        fullUrl
                        urlName
                    }}
                    jobProfileSector {{
                        contentItems {{
                        displayText
                        }}
                    }}
                    }}
                }}";

            Func<JobProfileResponse, List<JobProfile>> jobProfileSeclector = col =>
            {
                return col?.JobProfiles ?? new List<JobProfile>();
            };

            var responseJobProfiles = await _cmsQueryManager.GetDataWithPagination(jobProfileQuery, cacheKey: Guid.NewGuid().ToString(), jobProfileSeclector);

            if (responseJobProfiles.Data == null)
            {
                return null;
            }

            responseJobProfiles.Data[0].JobSectorTitle = response.Data[0].DisplayText;

            var JobSectorDisplayTexts = new List<string>();

            for (int i = 0; i < responseJobProfiles.Data.Count; i++)
            {

                var jobProfileSector = responseJobProfiles.Data[i].JobProfileSector;


                if (jobProfileSector != null && jobProfileSector.ContentItems != null)
                {

                    for (int j = 0; j < jobProfileSector.ContentItems.Count; j++)
                    {
                        JobSectorDisplayTexts.Add(jobProfileSector.ContentItems[j].DisplayText);
                    }
                }
            }

            var formattedJobSectorDisplayTexts = string.Join(", ", JobSectorDisplayTexts.Select(text => $"\"{text}\""));

            //var formattedcontentItemIds = string.Join(", ", contentItemIds.Select(id => $"\"{id}\""));


            //string sectorLandingPageUrlQuery = $@"
            //    query MyQuery {{
            //      jobProfileSector(
            //        where: {{contentItemId_in: [{formattedcontentItemIds}]}},
            //        status: {NcsGraphQLTokens.GraphQLStatusToken}, first: {NcsGraphQLTokens.PaginationCountToken}, skip: {NcsGraphQLTokens.SkipCountToken}
            //      ) {{
            //        contentItemId
            //        displayText
            //        sectorLandingPage {{
            //          contentItems {{
            //            displayText
            //            contentItemId
            //            ... on SectorLandingPage {{
            //              displayText
            //              modifiedUtc
            //              pageLocation {{
            //                fullUrl
            //                urlName
            //              }}
            //            }}
            //          }}
            //        }}
            //      }}
            //    }}";


            string sectorLandingPageUrlQuery = $@"
                query MyQuery {{
                  jobProfileSector(
                    where: {{displayText_in: [{formattedJobSectorDisplayTexts}]}},
                    status: {NcsGraphQLTokens.GraphQLStatusToken}, first: {NcsGraphQLTokens.PaginationCountToken}, skip: {NcsGraphQLTokens.SkipCountToken}
                  ) {{
                    contentItemId
                    displayText
                    sectorLandingPage {{
                      contentItems {{
                        displayText
                        contentItemId
                        ... on SectorLandingPage {{
                          displayText
                          modifiedUtc
                          pageLocation {{
                            fullUrl
                            urlName
                          }}
                        }}
                      }}
                    }}
                  }}
                }}";

            Func<JSLUrl.JobProfileSectorResponse, List<JobSectorLandingUrl>> jobSectorLandingUrl = col =>
            {
                return col?.JobProfileSector ?? new List<JobSectorLandingUrl>();
            };

            var responseJobSectorLandingUrl = await _cmsQueryManager.GetDataWithPagination(sectorLandingPageUrlQuery, cacheKey: Guid.NewGuid().ToString(), jobSectorLandingUrl);

            if (responseJobSectorLandingUrl.Data == null)
            {
                return null;
            }

            Dictionary<string, string> kvp = new Dictionary<string, string>();


            for (int i = 0; i < responseJobSectorLandingUrl.Data.Count; i++)
            {
                var sectorLandingPage = responseJobSectorLandingUrl.Data[i].SectorLandingPage;

                // Check if SectorLandingPage and ContentItems are not null
                if (sectorLandingPage != null && sectorLandingPage.ContentItems != null && sectorLandingPage.ContentItems.Count > 0)
                {
                    // Ensure that the index for ContentItems does not exceed its length
                    for (int j = 0; j < sectorLandingPage.ContentItems.Count; j++)
                    {
                        // Add to your KeyValuePair or dictionary
                        //kvp.Add(sectorLandingPage.ContentItems[j].DisplayText, sectorLandingPage.ContentItems[j].PageLocation.FullUrl);

                        var fullUrlValue = $"sector-page={sectorLandingPage.ContentItems[j].PageLocation.FullUrl.TrimStart('/')}&id={sectorLandingPage.ContentItems[j].ContentItemId}";

                        kvp.Add(sectorLandingPage.ContentItems[j].DisplayText, fullUrlValue);
                    }
                }
            }


            for (int i = 0; i < responseJobProfiles.Data.Count; i++)
            {

                var jobProfileSector = responseJobProfiles.Data[i].JobProfileSector;


                if (jobProfileSector != null && jobProfileSector.ContentItems != null)
                {

                    for (int j = 0; j < jobProfileSector.ContentItems.Count; j++)
                    {
                        var textToDisplay = jobProfileSector.ContentItems[j].DisplayText.ToLower(); // Convert the lookup key to lowercase

                        // Convert the dictionary to use lowercase keys
                        var lowerCaseDictionary = kvp.ToDictionary(k => k.Key.ToLower(), v => v.Value);

                        // Try to find the FullUrl in the dictionary using the lowercase DisplayText as the key
                        if (lowerCaseDictionary.TryGetValue(textToDisplay, out string fullUrl))
                        {
                            responseJobProfiles.Data[i].JobProfileSector.ContentItems[j].FullUrl = $"{fullUrl}";
                        }
                    }
                }
            }

            return responseJobProfiles.Data;
        }
    }
}
