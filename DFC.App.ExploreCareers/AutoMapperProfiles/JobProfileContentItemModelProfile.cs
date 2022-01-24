using System.Diagnostics.CodeAnalysis;

using AutoMapper;

using DFC.App.ExploreCareers.AzureSearch;
using DFC.App.ExploreCareers.Data.Models.CmsApiModels;
using DFC.App.ExploreCareers.Data.Models.ContentModels;
using DFC.App.ExploreCareers.ViewModels;
using DFC.App.ExploreCareers.ViewModels.JobCategories;

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

            CreateMap<JobProfileIndex, JobProfileByCategoryViewModel>()
                .ForMember(d => d.AlternativeTitle, o => o.MapFrom(s => s.AlternativeTitle != null ? string.Join(", ", s.AlternativeTitle).Trim().TrimEnd(',') : string.Empty));
        }
    }
}
