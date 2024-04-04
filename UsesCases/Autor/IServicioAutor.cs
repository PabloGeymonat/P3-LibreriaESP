using Domain.Dtos;
using Domain.Models;

namespace UsesCases
{

    public interface IServicioAutor : IServicioCRUD<AutorDto>
    {
        IEnumerable<AutorDto> GetByName(string name);
        IEnumerable<AutorDto> GetFechaDeNacimentoEntreDosFechas(DateTime desde, DateTime hasta);
        IEnumerable<AutorDto> GetFechaDeFallecimientoEntreDosFechas(DateTime desde, DateTime hasta);
        IEnumerable<AutorDto> GetNacionalidad(int nacionalidadId);
    }

}