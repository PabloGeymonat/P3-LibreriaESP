using Domain.Interfaces;
using Domain.Utils;

namespace Domain.Models;

public class Parametro: IValidable, ICopiable<Parametro>
{
    public string Clave { get; set; }
    public string Valor { get; set; }

    public Parametro()
    {
    }

    public void Validar()
    {
        Util.ThrowExceptionIfEmptyString(Clave, "La clave no puede ser vacía");
        Util.ThrowExceptionIfEmptyString(Valor, "El valor no puede ser vacío");
    }

    public void Copy(Parametro model)
    {
        Valor = model.Valor;
    }
}