using AutoMapper;
using Domain.Dtos;
using Domain.Models;

namespace UsesCases.AutoMapper;

public class PublicacionProfile: Profile
{
    public PublicacionProfile()
    {
        CreateMap<PublicacionDto, Publicacion>();
        CreateMap<Publicacion, PublicacionDto>()
            .Include<Libro, LibroDto>()
            .Include<Revista, RevistaDto>()
            .ForMember(dest => dest.TemaDto, act => act.MapFrom(src => src.Tema))
            .ForMember(dest => dest.EditorialDto, act => act.MapFrom(src => src.Editorial));
            
            
    }
}