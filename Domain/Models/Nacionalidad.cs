using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Utils;

namespace Domain.Models;

public class Nacionalidad: IValidable, IIdentityById, ICopiable<Nacionalidad>
{
    public int Id { get; set; }
    public string Nombre { get; set; }
 
    public void Validar()
    {
        Util.ThrowExceptionIfEmptyString(Nombre, "El nombre de la nacionalidad no puede ser vacío");
    }

    public void Copy(Nacionalidad model)
    {
        Nombre = model.Nombre;
    }
}