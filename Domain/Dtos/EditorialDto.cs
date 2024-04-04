using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
using Domain.Utils;

namespace Domain.Dtos;

public class EditorialDto: IValidable, IIdentityById
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public PaisDto PaisOrigenDto { get; set; }
    public int PaisOrigenId { get; set; }

    public void Validar()
    {
        Util.ThrowExceptionIfEmptyString(Nombre, "El nombre de la editorial no puede ser vacío");
        Util.ThrowExceptionIfZero(PaisOrigenId, "Falta el pais de origen");
        
    }
   
}
