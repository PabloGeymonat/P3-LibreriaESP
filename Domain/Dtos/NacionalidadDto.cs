using Domain.Exceptions;
using Domain.Interfaces;

namespace Domain.Dtos;

public class NacionalidadDto: IValidable, IIdentityById
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public void Validar()
    {
        if (String.IsNullOrEmpty(Nombre))
        {
            throw new ElementoInvalidoException("El nombre de la nacionalidad no puede ser vacío");
        }
    }
}