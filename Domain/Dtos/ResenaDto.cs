namespace Domain.Dtos;

public class ResenaDto
{
    public int Id { get; set; }
    public PublicacionDto PublicacionDto { get; set; }
    public string Texto { get; set; }
    public int Puntaje { get; set; }
    
}
