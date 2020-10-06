using AutoMapper;
using DFC.App.ExploreCareers.Models.AzureSearch;
using DFC.App.ExploreCareers.ViewModels.SearchResults;

namespace DFC.App.ExploreCareers.AutoMapperProfiles
{
    public class SearchResultsViewModelProfile : Profile
    {
        public SearchResultsViewModelProfile()
        {
            CreateMap<AzureSearchJobProfileModel, SearchResultsViewModel>()
                .ForMember(d => d.JobProfiles, s => s.MapFrom(a => a.Value))
                .ForMember(d => d.TotalPages, s => s.MapFrom(a => a.TotalPages))
                .ForMember(d => d.TotalResults, s => s.MapFrom(a => a.DocumentTotal))
                .ForMember(d => d.CurrentPage, s => s.Ignore())
                .ForMember(d => d.SearchTerm, s => s.Ignore())
                ;
        }
    }
}
