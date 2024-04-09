using AutoMapper;
using Domain.Dtos;
using Domain.Models;

namespace UsesCases.AutoMapper;

public class RevistaProfile: Profile
{
    public RevistaProfile()
    {
        CreateMap<RevistaDto, Revista>();
        CreateMap<Revista, RevistaDto>()
            .ForMember(dest => dest.TemaDto, act => act.MapFrom(src => src.Tema))
            .ForMember(dest => dest.EditorialDto, act => act.MapFrom(src => src.Editorial));
    }
}