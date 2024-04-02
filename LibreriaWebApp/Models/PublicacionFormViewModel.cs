using Domain.Dtos;

namespace LibreriaWebApp.Models;

public class PublicacionFormViewModel
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

    public IEnumerable<TemaDto> posiblesTemas { get; set; }
    public IEnumerable<EditorialDto> posiblesEditoriales { get; set; }
    


}