using Domain.Dtos;
using Domain.Models;

namespace UsesCases
{

    public interface IServicioTema : IServicioCRUD<TemaDto>
    {
        IEnumerable<TemaDto> GetByName(string nombre);
    }
}