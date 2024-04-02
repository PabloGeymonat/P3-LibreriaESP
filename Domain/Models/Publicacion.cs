using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Utils;

namespace Domain.Models;

public abstract class Publicacion: IValidable, IIdentityById, ICopiable<Publicacion>
{
    public int Id { get; set; }
    public Tema Tema { get; set; }
    
    public int TemaId { get; set; }
    public Editorial Editorial { get; set; }
    
    public int EditorialId { get; set; }
    public decimal PrecioSugerido { get; set; }
    public DateTime FechaPublicacion { get; set; }
    public int CantidadPaginas { get; set; }
    public string ImagenPortada { get; set; }
    public int Stock { get; set; }

    // Relación muchos a muchos con Autor
    public IList<PublicacionAutor> Autores { get; set; } = new List<PublicacionAutor>();

    
    
    public virtual void Validar()
    {
        Util.ThrowExceptionIfZero(TemaId, "Falta el tema de la publicación");
        Util.ThrowExceptionIfZero(EditorialId, "Falta la editorial de la publicación");
        Util.ThrowExceptionIfNegativeNumber(PrecioSugerido, "El precio sugerido no puede ser negativo");
        Util.ThrowExceptionIfNegativeNumber(CantidadPaginas, "La cantidad de página no puede ser negativo");
        Util.ThrowExceptionIfNegativeNumber(Stock, "El stock no puede ser negativo");
        Util.ThrowExceptionIfFutureDate(FechaPublicacion, "La fecha de la publicación no puede ser fecha futura");
    }

    public void Copy(Publicacion model)
    {
        TemaId = model.TemaId;
        EditorialId = model.EditorialId;
        PrecioSugerido = model.PrecioSugerido;
        FechaPublicacion = model.FechaPublicacion;
        CantidadPaginas = model.CantidadPaginas;
        ImagenPortada = model.ImagenPortada;
        Stock = model.Stock;
    }
}
