
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace DataAccess
{
    public class RepositorioRevista : Repository<Revista>, IRepositoryRevista
    {
        public RepositorioRevista(DbContext dbContext) 
        {
            Contexto = dbContext;
        }


        public IEnumerable<Revista> GetByName(string nombre)
        {
            IEnumerable<Revista> Revistas = Contexto.Set<Revista>()
                                        .Include(r=>r.Editorial)
                                        .Include(r=>r.Tema)
                                        .Where(Revista => Revista.Nombre.Contains(nombre));
            return Revistas;
        }
        
        public override Revista Get(int id)
        {
            Revista revista = Contexto.Set<Revista>()
                .Include(r=>r.Editorial)
                .Include(r=>r.Tema)
                .FirstOrDefault(e => e.Id == id);
                
            return revista;
        }
    }
}
