
using Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace DataAccess
{
    public class RepositorioEditorial : Repository<Editorial>, IRepositoryEditorial
    {
        public RepositorioEditorial(DbContext dbContext) 
        {
            Contexto = dbContext;
        }


        public IEnumerable<Editorial> GetByName(string nombre)
        {
            IEnumerable<Editorial> Editorials = Contexto.Set<Editorial>()
                                        .Include(p=>p.PaisOrigen)
                                        .Where(Editorial => Editorial.Nombre.Contains(nombre));
            return Editorials;
        }
        
        public override Editorial Get(int id)
        {
            Editorial editorial = Contexto.Set<Editorial>()
                .Include(p =>p.PaisOrigen)
                .FirstOrDefault(e => e.Id == id);
                
            return editorial;
        }
    }
}
