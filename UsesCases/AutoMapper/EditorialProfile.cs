using AutoMapper;
using Domain.Dtos;
using Domain.Models;

namespace UsesCases.AutoMapper;

public class EditorialProfile: Profile
{
    
    public EditorialProfile()
    {
        
        CreateMap<EditorialDto, Editorial>();
        // Mapeo de Pais a PaisDto
       // Mapeo de Editorial a EditorialDto, incluyendo la Pais
        CreateMap<Editorial, EditorialDto>()
            .ForMember(dest => dest.PaisOrigenDto, act => act.MapFrom(src => src.PaisOrigen));
    }
}