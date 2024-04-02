
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace DataAccess
{
    public class RepositorioTema : Repository<Tema>, IRepositoryTema
    {
        public RepositorioTema(DbContext dbContext) 
        {
            Contexto = dbContext;
        }


        public IEnumerable<Tema> GetByName(string nombre)
        {
            IEnumerable<Tema> temas = Contexto.Set<Tema>()
                                        .Where(tema => tema.Nombre.Contains(nombre));
            return temas;
        }
    }
}
