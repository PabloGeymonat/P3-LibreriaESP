using Domain.Interfaces;

namespace Domain.Dtos;

public class AutorDto: IValidable
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public DateTime? FechaDefuncion { get; set; } // Nullable porque es opcional
    public NacionalidadDto NacionalidadDto { get; set; }
    public int NacionalidadId { get; set; } 
    
    
    public IList<PublicacionAutorDto> Publicaciones { get; set; } = new List<PublicacionAutorDto>();
    public void Validar()
    {
       return;
    }
   
}
