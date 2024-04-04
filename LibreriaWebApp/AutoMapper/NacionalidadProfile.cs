using AutoMapper;
using Domain.Dtos;
using Domain.Models;

namespace UsesCases.AutoMapper;

public class NacionalidadProfile: Profile
{
    public NacionalidadProfile()
    {
        CreateMap<Nacionalidad, NacionalidadDto>();
        CreateMap<NacionalidadDto, Nacionalidad>();
    }
}