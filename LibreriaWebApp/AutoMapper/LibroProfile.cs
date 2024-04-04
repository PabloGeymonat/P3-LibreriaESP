using AutoMapper;
using Domain.Dtos;
using Domain.Models;

namespace UsesCases.AutoMapper;

public class LibroProfile: Profile
{
    public LibroProfile()
    {
        CreateMap<LibroDto, Libro>();
        CreateMap<Libro, LibroDto>()
            .ForMember(dest => dest.TemaDto, act => act.MapFrom(src => src.Tema))
            .ForMember(dest => dest.EditorialDto, act => act.MapFrom(src => src.Editorial));
    }
}