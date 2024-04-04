namespace Domain.Models;

public class PublicacionAutor
{
    public int PublicacionId { get; set; }
    public Publicacion Publicacion { get; set; }
    
    public int AutorId { get; set; }
    public Autor Autor { get; set; }
    

}
