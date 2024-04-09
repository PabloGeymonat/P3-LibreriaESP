using Domain.Interfaces;
using Domain.Utils;

namespace Domain.Dtos;

public class ParametroDto: IValidable
{
    public string Clave { get; set; }
    public string Valor { get; set; }

    public void Validar()
    {
        Util.ThrowExceptionIfEmptyString(Clave, "La clave no puede ser vacía");
        Util.ThrowExceptionIfEmptyString(Valor, "El valor no puede ser vacío");
    }
}