using AutoMapper;
using Domain.Dtos;
using Domain.Models;

namespace UsesCases.AutoMapper;

public class FacturaDeCompraProfile: Profile
{
    
    public FacturaDeCompraProfile()
    {
        
        CreateMap<FacturaDeCompraDto, FacturaDeCompra>();
        // Mapeo de Nacionalidad a NacionalidadDto
       // Mapeo de FacturaDeCompra a FacturaDeCompraDto, incluyendo la Nacionalidad
        CreateMap<FacturaDeCompra, FacturaDeCompraDto>()
            .ForMember(dest => dest.ProveedorDto, act => act.MapFrom(src => src.Proveedor));
    }
}