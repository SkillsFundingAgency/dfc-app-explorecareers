using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using AutoMapper;

using DFC.App.ExploreCareers.AzureSearch;
using DFC.App.ExploreCareers.Data.Models.CmsApiModels;
using DFC.App.ExploreCareers.Data.Models.ContentModels;
using DFC.App.ExploreCareers.ViewModels;
using DFC.App.ExploreCareers.ViewModels.JobCategories;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles.JobProfileCategory;

namespace DFC.App.ExploreCareers.AutoMapperProfiles
{
    [ExcludeFromCodeCoverage]
    public class JobProfileContentItemModelProfile : Profile
    {
        public JobProfileContentItemModelProfile()
        {
            CreateMap<CmsApiJobCategoryModel, JobCategoryContentItemModel>()
                .ForMember(d => d.Id, s => s.MapFrom(x => x.ItemId))
                .ForMember(d => d.PartitionKey, s => s.MapFrom(x => x.PageLocation))
                .ForMember(d => d.Etag, s => s.Ignore())
                .ForMember(d => d.TraceId, s => s.Ignore())
                .ForMember(d => d.ParentId, s => s.Ignore());

            CreateMap<JobCategoryContentItemModel, JobCategoryViewModel>()
                .ForMember(d => d.Name, s => s.MapFrom(x => x.Title));

            CreateMap<JobProfileCategory, JobCategoryViewModel>()
                .ForMember(d => d.Name, s => s.MapFrom(x => x.DisplayText))
                .ForMember(d => d.CanonicalName, s => s.MapFrom(x => x.PageLocation.UrlName));

            //TODO: Fix FullUrl to URlName and check if working
            /*CreateMap<JobProfile, JobProfileIndex>()
                .ForMember(d => d.Title, s => s.MapFrom(x => x.Title))
                .ForMember(d => d.AlternativeTitle, s => s.MapFrom(x => x.AlternativeTitle))
                .ForMember(d => d.Overview, s => s.MapFrom(x => x.Overview))
                .ForMember(d => d.UrlName, s => s.MapFrom(x => x.FullUrl.Substring(13)))
                .ForMember(d => d.SalaryStarter, s => s.Ignore())
                .ForMember(d => d.SalaryExperienced, s => s.Ignore())
                .ForMember(d => d.EntryQualificationLowestLevel, s => s.Ignore())
                .ForMember(d => d.MinimumHours, s => s.Ignore())
                .ForMember(d => d.MaximumHours, s => s.Ignore())
                .ForMember(d => d.Rank, s => s.Ignore());*/

            CreateMap<JobProfileIndex, JobProfileByCategoryViewModel>()
                .ForMember(d => d.AlternativeTitle, o => o.MapFrom(s => s.AlternativeTitle != null ? string.Join(", ", s.AlternativeTitle).Trim().TrimEnd(',') : string.Empty));

            CreateMap<JobProfileIndex, JobProfileViewModel>()
                .ForMember(d => d.ResultItemTitle, s => s.MapFrom(x => x.Title))
                .ForMember(d => d.ResultItemUrlName, s => s.MapFrom(x => x.UrlName))
                .ForMember(d => d.ResultItemAlternativeTitle, s => s.MapFrom(x => string.Join(", ", x.AlternativeTitle ?? Array.Empty<string>())))
                .ForMember(d => d.ResultItemOverview, s => s.MapFrom(x => x.Overview))
                .ForMember(d => d.ResultItemSalaryRange, s => s.MapFrom(x => GetSalaryRange(x)))
                .ForMember(d => d.JobProfileCategoriesWithUrl, s => s.MapFrom(x => x.JobProfileCategoriesWithUrl ?? Array.Empty<string>()))

                .ForMember(d => d.Score, s => s.Ignore())
                .ForMember(d => d.ShouldDisplayCaveat, s => s.Ignore())
                .ForMember(d => d.MatchingSkillsCount, s => s.Ignore())
                ;
        }

        private static string GetSalaryRange(JobProfileIndex x)
        {
            return (x.SalaryStarter is 0 || x.SalaryExperienced is 0)
                ? "Variable"
                : string.Format(new CultureInfo("en-GB", false), "{0:C0} to {1:C0}", x.SalaryStarter, x.SalaryExperienced);
        }
    }
}
