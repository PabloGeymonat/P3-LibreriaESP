using Domain.Dtos;
using Domain.Models;

namespace UsesCases
{

    public interface IServicioLibro : IServicioCRUD<LibroDto>
    {
        IEnumerable<LibroDto> GetByISBN(string nombre);
    }
}