
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace DataAccess
{
    public class RepositorioRevista : Repository<Revista>, IRepositoryRevista
    {
        public RepositorioRevista(DbContext dbContext) 
        {
            contexto = dbContext;
        }


        public IEnumerable<Revista> GetByName(string nombre)
        {
            IEnumerable<Revista> Revistas = contexto.Set<Revista>()
                                        .Include(r=>r.Editorial)
                                        .Include(r=>r.Tema)
                                        .Where(Revista => Revista.Nombre.Contains(nombre));
            return Revistas;
        }
        
        public override Revista Get(int id)
        {
            Revista revista = contexto.Set<Revista>()
                .Include(r=>r.Editorial)
                .Include(r=>r.Tema)
                .FirstOrDefault(e => e.Id == id);
                
            return revista;
        }
    }
}
