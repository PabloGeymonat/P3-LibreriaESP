using AutoMapper;
using Domain.Dtos;
using Domain.Models;

namespace UsesCases.AutoMapper;

public class ParametroProfile: Profile
{
    public ParametroProfile()
    {
        CreateMap<Parametro, ParametroDto>();
        CreateMap<ParametroDto, Parametro>();
    }
}