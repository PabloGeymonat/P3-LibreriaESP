using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Utils;

namespace Domain.Dtos;

public class PaisDto: IValidable, IIdentityById
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public void Validar()
    {
        Util.ThrowExceptionIfEmptyString(Nombre,"El nombre del pais no puede ser vacío");
        
    }

}