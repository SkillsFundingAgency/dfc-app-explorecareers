using System.Diagnostics.CodeAnalysis;

using AutoMapper;

using DFC.App.ExploreCareers.Data.Models.CmsApiModels;
using DFC.App.ExploreCareers.Data.Models.ContentModels;
using DFC.App.ExploreCareers.ViewModels;

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
        }
    }
}
