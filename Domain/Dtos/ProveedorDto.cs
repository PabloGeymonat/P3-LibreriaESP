using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
using Domain.Utils;

namespace Domain.Dtos;

public class ProveedorDto: IValidable, IIdentityById
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    // Información adicional del proveedor
    public void Validar()
    {
        Util.ThrowExceptionIfEmptyString(Nombre, "Falta el nombre del proveedor");
    }
}
