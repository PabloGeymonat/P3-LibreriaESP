using Domain.Dtos;

namespace LibreriaWebApp.Models;

public class RevistaFormViewModel: PublicacionFormViewModel
{
    public string Nombre { get; set; }
    public int Numero { get; set; }
    public int Anio { get; set; }
    public string TablaContenido { get; set; }

    public RevistaFormViewModel()
    {
    }

    public RevistaFormViewModel(RevistaDto revistaDto)
    {
        Id = revistaDto.Id;
        TemaDto = revistaDto.TemaDto;
        TemaId = TemaDto.Id;
        EditorialDto = revistaDto.EditorialDto;
        EditorialId = EditorialDto.Id;
        PrecioSugerido = revistaDto.PrecioSugerido;
        FechaPublicacion = revistaDto.FechaPublicacion;
        CantidadPaginas = revistaDto.CantidadPaginas;
        ImagenPortada = revistaDto.ImagenPortada;
        Stock = revistaDto.Stock;
        Nombre = revistaDto.Nombre;
        Numero = revistaDto.Numero;
        Anio = revistaDto.Anio;
        TablaContenido = revistaDto.TablaContenido;
        
    }

    public RevistaDto ToRevistaDto()
    {
        RevistaDto revistaDto = new RevistaDto
        {
            Id = Id,
            TemaDto = null,
            TemaId = TemaId,
            EditorialDto = null,
            EditorialId = EditorialId,
            PrecioSugerido = PrecioSugerido,
            FechaPublicacion = FechaPublicacion,
            CantidadPaginas = 0,
            ImagenPortada = ImagenPortada,
            Stock = 0,
            Autores = null,
            Nombre = Nombre,
            Numero = Numero,
            Anio = Anio,
            TablaContenido = TablaContenido
        };
        return revistaDto;
    }
}