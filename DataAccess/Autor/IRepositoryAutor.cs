

using Domain.Models;

namespace DataAccess
{
    public interface IRepositoryAutor: IRepository<Autor>
    {
        IEnumerable<Autor> GetByName(string name);
        IEnumerable<Autor> GetFechaDeNacimentoEntreDosFechas(DateTime desde, DateTime hasta);
        IEnumerable<Autor> GetFechaDeFallecimientoEntreDosFechas(DateTime desde, DateTime hasta);
        IEnumerable<Autor> GetNacionalidad(int nacionalidadId);
        
    }
}
