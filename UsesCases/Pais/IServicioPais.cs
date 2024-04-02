using Domain.Dtos;
using Domain.Models;

namespace UsesCases
{

    public interface IServicioPais : IServicioCRUD<PaisDto>
    {
        IEnumerable<PaisDto> GetByName(string nombre);
    }
}