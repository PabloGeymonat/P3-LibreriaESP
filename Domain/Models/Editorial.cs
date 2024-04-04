using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Utils;

namespace Domain.Models;

public class Editorial: IValidable, IIdentityById, ICopiable<Editorial>
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public Pais PaisOrigen { get; set; }
    public int PaisOrigenId { get; set;  }

    public void Validar()
    {
        Util.ThrowExceptionIfEmptyString(Nombre, "El nombre de la editorial no puede ser vacío");
        
    }

    public void Copy(Editorial model)
    {
        Nombre = model.Nombre;
        PaisOrigen = model.PaisOrigen;
        PaisOrigenId = model.PaisOrigenId;
    }
}
