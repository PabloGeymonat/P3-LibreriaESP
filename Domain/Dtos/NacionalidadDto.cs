using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Utils;

namespace Domain.Dtos;

public class NacionalidadDto: IValidable, IIdentityById
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public void Validar()
    {
        Util.ThrowExceptionIfEmptyString(Nombre,"El nombre de la nacionalidad no puede ser vacío");
    }
}