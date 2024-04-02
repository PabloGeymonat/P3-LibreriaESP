using Domain.Exceptions;
using Domain.Interfaces;

namespace Domain.Dtos;

public class PaisDto: IValidable, IIdentityById
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public void Validar()
    {
        if (String.IsNullOrEmpty(Nombre))
        {
            throw new ElementoInvalidoException("El nombre del pais no puede ser vacío");
        }
    }

}