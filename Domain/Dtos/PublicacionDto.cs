using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
using Domain.Utils;

namespace Domain.Dtos;

public abstract class PublicacionDto: IValidable, IIdentityById
{
    public int Id { get; set; }
    public TemaDto TemaDto { get; set; }
    public int TemaId { get; set; }
    public EditorialDto EditorialDto { get; set; }
    public int EditorialId { get; set; }
    public decimal PrecioSugerido { get; set; }
    public DateTime FechaPublicacion { get; set; }
    public int CantidadPaginas { get; set; }
    public string ImagenPortada { get; set; }
    public int Stock { get; set; }
    public IList<PublicacionAutorDto> Autores { get; set; } = new List<PublicacionAutorDto>();
    
    public virtual void Validar()
    {
        Util.ThrowExceptionIfZero(TemaId, "Falta el tema de la publicación");
        Util.ThrowExceptionIfZero(EditorialId, "Falta la editorial de la publicación");
        Util.ThrowExceptionIfNegativeNumber(PrecioSugerido, "El precio sugerido no puede ser negativo");
        Util.ThrowExceptionIfNegativeNumber(CantidadPaginas, "La cantidad de página no puede ser negativo");
        Util.ThrowExceptionIfNegativeNumber(Stock, "El stock no puede ser negativo");
        Util.ThrowExceptionIfFutureDate(FechaPublicacion, "La fecha de la publicación no puede ser fecha futura");
    }
    
}
