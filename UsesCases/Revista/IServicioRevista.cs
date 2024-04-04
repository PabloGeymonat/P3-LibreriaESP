using Domain.Dtos;
using Domain.Models;

namespace UsesCases
{
    public interface IServicioRevista : IServicioCRUD<RevistaDto>
    {
        IEnumerable<RevistaDto> GetByName(string nombre);
    }
}