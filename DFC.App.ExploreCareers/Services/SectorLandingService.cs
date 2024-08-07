using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using DFC.App.ExploreCareers.Interfaces;
using DFC.App.ExploreCareers.ViewModels.SectorLandingPage;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBanner;
using DfE.NCS.Framework.Core.Constants;
using DfE.NCS.Framework.Core.Repository;
using DfE.NCS.Framework.Core.Repository.Interface;
using DfE.NCS.Framework.SharedContent.Cms;
using DfE.NCS.Framework.SharedContent.Cms.Model;
using Microsoft.Extensions.Logging;

namespace DFC.App.ExploreCareers.Services
{
    public class SectorLandingService : CmsRepositoryBase, ISectorLandingService
    {
        public const string CacheKeySector = "sector-landing-page";

        /// <summary>
        /// Initializes a new instance of the <see cref="SectorLandingService"/> class.
        /// </summary>
        /// <param name="querymanager">The querymanager.</param>
        /// <param name="logger">The logger.</param>
        public SectorLandingService(ICmsQueryManager querymanager, ILogger<CmsRepositoryBase> logger) : base(querymanager, logger)
        {
        }

        public async Task<List<SectorLandingPage>> GetItemByKey(string pageUrl)
        {
            string query = $@"query MyQuery {{
                                      sectorLandingPage(status: {NcsGraphQLTokens.GraphQLStatusToken}, first: {NcsGraphQLTokens.PaginationCountToken}, skip: {NcsGraphQLTokens.SkipCountToken},, where: {{ pageLocation:{{ url: ""{pageUrl}""}}}}) {{
                                        contentItemId
                                        graphSync {{
                                          nodeId
                                        }}
                                        render
                                        heroBanner{{
                                          html
                                        }}
                                        aboutThisSector
                                        description{{
                                          html
                                        }}
                                        pageLocation{{
                                          fullUrl
                                        }}
                                      }}
                                    }}";

            try
            {
                Func<SectorLandingPageResponse, List<SectorLandingPage>> recSelector = col => col.SectorLandingPage;
                var response = await _cmsQueryManager.GetDataWithPagination(query, CacheKeySector, recSelector);
                return response.Data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<SectorLandingPage>> LoadAll()
        {
            string query = $@"query MyQuery {{
                                      sectorLandingPage(status: {NcsGraphQLTokens.GraphQLStatusToken}, first: {NcsGraphQLTokens.PaginationCountToken}, skip: {NcsGraphQLTokens.SkipCountToken}) {{
                                        contentItemId
                                        graphSync {{
                                          nodeId
                                        }}
                                        render
                                        heroBanner{{
                                          html
                                        }}
                                        aboutThisSector
                                        description{{
                                          html
                                        }}
                                        pageLocation{{
                                          fullUrl
                                        }}
                                      }}
                                    }}";

            try
            {
                Func<SectorLandingPageResponse, List<SectorLandingPage>> recSelector = col => col.SectorLandingPage;
                var response = await _cmsQueryManager.GetDataWithPagination(query, CacheKeySector, recSelector);
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
