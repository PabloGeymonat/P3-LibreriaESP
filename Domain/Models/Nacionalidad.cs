using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Utils;

namespace Domain.Models;

public class Nacionalidad: IValidable, IIdentityById, ICopiable<Nacionalidad>
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public List<Autor> Autores { get; set; } 
    public void Validar()
    {
        Util.ThrowExceptionIfEmptyString(Nombre, "El nombre de la nacionalidad no puede ser vacío");
    }

    protected bool Equals(Nacionalidad other)
    {
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Nacionalidad)obj);
    }

    public override int GetHashCode()
    {
        return Id;
    }

    public void Copy(Nacionalidad model)
    {
        Nombre = model.Nombre;
    }
}