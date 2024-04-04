
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace DataAccess
{
    public class RepositorioLibro : Repository<Libro>, IRepositoryLibro
    {
        public RepositorioLibro(DbContext dbContext) 
        {
            Contexto = dbContext;
        }


        public IEnumerable<Libro> GetByISBN(string ISBN)
        {
            IEnumerable<Libro> Libros = Contexto.Set<Libro>()
                                        .Include(r=>r.Editorial)
                                        .Include(r=>r.Tema)
                                        .Where(l => l.ISBN.Contains(ISBN));
            return Libros;
        }
        
        public override Libro Get(int id)
        {
            Libro Libro = Contexto.Set<Libro>()
                .Include(r=>r.Editorial)
                .Include(r=>r.Tema)
                .FirstOrDefault(e => e.Id == id);
            return Libro;
        }
    }
}
