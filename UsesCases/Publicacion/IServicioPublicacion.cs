using Domain.Dtos;
using Domain.Models;

namespace UsesCases
{
    public interface IServicioPublicacion
    {
        IEnumerable<PublicacionDto> GetAll();
    }
}