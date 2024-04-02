using Domain.Dtos;
using Domain.Models;

namespace UsesCases
{

    public interface IServicioEditorial : IServicioCRUD<EditorialDto>
    {
        IEnumerable<EditorialDto> GetByName(string nombre);
    }
}