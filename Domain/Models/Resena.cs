namespace Domain.Models;

public class Resena
{
    public int Id { get; set; }
    public int PublicacionId { get; set; }
    public Publicacion Publicacion { get; set; }
    public string Texto { get; set; }
    public int Puntaje { get; set; }
  
}
