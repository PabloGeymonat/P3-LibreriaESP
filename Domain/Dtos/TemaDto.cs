using Domain.Exceptions;
using Domain.Interfaces;

namespace Domain.Dtos;

public class TemaDto: IValidable
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    // Validaciones adicionales según las reglas de negocio
    public void Validar()
    {
        if (String.IsNullOrEmpty(Nombre))
        {
            throw new ElementoInvalidoException("El nombre del tema no puede ser vacío");
        }
    }
  
}