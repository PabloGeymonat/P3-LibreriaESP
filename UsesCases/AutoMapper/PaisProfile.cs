using AutoMapper;
using Domain.Dtos;
using Domain.Models;

namespace UsesCases.AutoMapper;

public class PaisProfile: Profile
{
    public PaisProfile()
    {
        CreateMap<Pais, PaisDto>();
        CreateMap<PaisDto, Pais>();
    }
}