namespace Domain.Dtos;

public class PublicacionAutorDto
{
    public int PublicacionId { get; set; }
    public PublicacionDto PublicacionDto { get; set; }
    
    public int AutorId { get; set; }
    public AutorDto AutorDto { get; set; }

    // Atributos adicionales de la relación, si los hay
}
