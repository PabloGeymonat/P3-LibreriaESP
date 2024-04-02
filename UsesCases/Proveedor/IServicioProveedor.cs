using Domain.Dtos;
using Domain.Models;

namespace UsesCases
{

    public interface IServicioProveedor : IServicioCRUD<ProveedorDto>
    {
        IEnumerable<ProveedorDto> GetByName(string nombre);
    }
}