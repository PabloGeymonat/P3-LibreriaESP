using AutoMapper;
using Domain.Dtos;
using Domain.Models;

namespace UsesCases.AutoMapper;

public class AutorProfile: Profile
{
    
    public AutorProfile()
    {
        
        CreateMap<AutorDto, Autor>();
        // Mapeo de Nacionalidad a NacionalidadDto
       // Mapeo de Autor a AutorDto, incluyendo la Nacionalidad
        CreateMap<Autor, AutorDto>()
            .ForMember(dest => dest.NacionalidadDto, act => act.MapFrom(src => src.Nacionalidad));
    }
}