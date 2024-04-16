
using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace DataAccess
{
    public class RepositorioPais : Repository<Pais>, IRepositoryPais
    {
        public RepositorioPais(DbContext dbContext) 
        {
            contexto = dbContext;
        }


        public IEnumerable<Pais> GetByName(string nombre)
        {
            IEnumerable<Pais> Paiss = contexto.Set<Pais>()
                                        .Where(Pais => Pais.Nombre.Contains(nombre));
            return Paiss;
        }
    }
}
