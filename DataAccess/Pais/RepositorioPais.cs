
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace DataAccess
{
    public class RepositorioPais : Repository<Pais>, IRepositoryPais
    {
        public RepositorioPais(DbContext dbContext) 
        {
            Contexto = dbContext;
        }


        public IEnumerable<Pais> GetByName(string nombre)
        {
            IEnumerable<Pais> Paiss = Contexto.Set<Pais>()
                                        .Where(Pais => Pais.Nombre.Contains(nombre));
            return Paiss;
        }
    }
}
