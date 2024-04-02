
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace DataAccess
{
    public class RepositorioNacionalidad : Repository<Nacionalidad>, IRepositoryNacionalidad
    {
        public RepositorioNacionalidad(DbContext dbContext) 
        {
            Contexto = dbContext;
        }


        public IEnumerable<Nacionalidad> GetByName(string nombre)
        {
            IEnumerable<Nacionalidad> Nacionalidads = Contexto.Set<Nacionalidad>()
                                        .Where(Nacionalidad => Nacionalidad.Nombre.Contains(nombre));
            return Nacionalidads;
        }
    }
}
