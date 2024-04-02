using Domain.Dtos;
using Domain.Models;

namespace UsesCases
{

    public interface IServicioNacionalidad : IServicioCRUD<NacionalidadDto>
    {
        IEnumerable<NacionalidadDto> GetByName(string nombre);
    }
}