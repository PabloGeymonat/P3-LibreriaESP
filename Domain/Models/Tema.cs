using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Utils;

namespace Domain.Models;

public class Tema: IValidable, IIdentityById, ICopiable<Tema>
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public IEnumerable<Publicacion> Publicaciones { get; set; }

    public void Validar()
    {
        Util.ThrowExceptionIfEmptyString(Nombre, "El nombre del tema no puede ser vacío");
    }
 
    public void Copy(Tema model)
    {
        this.Nombre = model.Nombre;
    }
}