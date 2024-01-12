using DFC.App.ExploreCareers.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using DFC.Common.SharedContent.Pkg.Netcore;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using AutoMapper;
using NHibernate.Engine;
using DFC.Common.SharedContent.Pkg.Netcore.Repo;

namespace DFC.App.ExploreCareers.GraphQl
{
    public class GraphQlService : IGraphQlService
    {
        private readonly IRedisCMSRepo redisCMSRepo;
        private string status = string.Empty;

        public GraphQlService(IRedisCMSRepo redisCMSRepo)
        {
            this.redisCMSRepo = redisCMSRepo;
        }

        public async Task<List<JobCategoryViewModel>> GetJobCategoriesAsync()
        {
            status = "PUBLISHED";
            string query = @$"
                query MyQuery {{
                    jobProfileCategory(status: {status}){{
                        displayText
                        pageLocation{{
                            fullUrl
                            }}                        
                        }}
                    }}
            ";

            var response = await redisCMSRepo.GetGraphQLData<List<JobCategoryViewModel>>(query, "explorecareers/jobcategories");

            return response;
        }
    }
}
