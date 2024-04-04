using AutoMapper;
using Domain.Dtos;
using Domain.Models;

namespace UsesCases.AutoMapper;

public class ProveedorProfile: Profile
{
    public ProveedorProfile()
    {
        CreateMap<Proveedor, ProveedorDto>();
        CreateMap<ProveedorDto, Proveedor>();
    }
}