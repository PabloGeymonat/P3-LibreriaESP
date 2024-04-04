using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Utils;

namespace Domain.Dtos;

public class TemaDto: IValidable
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    // Validaciones adicionales según las reglas de negocio
    public void Validar()
    { 
        Util.ThrowExceptionIfEmptyString(Nombre, "El nombre del tema no puede ser vacío");
        
    }
  
}
