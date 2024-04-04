using Domain.Dtos;

namespace LibreriaWebApp.Models;

public class LibroFormViewModel: PublicacionFormViewModel
{
    public string ISBN { get; set; }
    public string Titulo { get; set; }
    

    public LibroFormViewModel()
    {
    }

    public LibroFormViewModel(LibroDto LibroDto)
    {
        Id = LibroDto.Id;
        TemaDto = LibroDto.TemaDto;
        TemaId = TemaDto.Id;
        EditorialDto = LibroDto.EditorialDto;
        EditorialId = EditorialDto.Id;
        PrecioSugerido = LibroDto.PrecioSugerido;
        FechaPublicacion = LibroDto.FechaPublicacion;
        CantidadPaginas = LibroDto.CantidadPaginas;
        ImagenPortada = LibroDto.ImagenPortada;
        Stock = LibroDto.Stock;
        ISBN = LibroDto.ISBN;
        Titulo = LibroDto.Titulo;
    }

    public LibroDto ToLibroDto()
    {
        LibroDto LibroDto = new LibroDto
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
            ISBN = ISBN,
            Titulo = Titulo
        };
        return LibroDto;
    }
}