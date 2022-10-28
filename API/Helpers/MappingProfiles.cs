using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Goal, GoalToReturnDTO>()
            .ForMember(d => d.GoalBrand, o => o.MapFrom(s => s.GoalBrand.Name))
            .ForMember(d => d.GoalCategory, o => o.MapFrom(s => s.GoalCategory.Name))
            .ForMember(d => d.PictureUrl, o => o.MapFrom<GoalUrlResolver>());
    }
}
