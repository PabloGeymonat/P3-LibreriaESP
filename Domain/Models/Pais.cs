using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Utils;

namespace Domain.Models;

public class Pais: IValidable, IIdentityById, ICopiable<Pais>
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public IEnumerable<Editorial> Editoriales { get; set; }

    public void Validar()
    {
        Util.ThrowExceptionIfEmptyString(Nombre, "El nombre del pais no puede ser vacío");
    }
    
    public void Copy(Pais model)
    {
        Nombre = model.Nombre;
    }
}