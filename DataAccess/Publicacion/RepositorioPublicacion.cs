
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Microsoft.Identity.Client;

namespace DataAccess
{
    public class RepositorioPublicacion: IRepositoryPublicacion
    {
        private DbContext _contexto;
        public RepositorioPublicacion(DbContext dbContext) 
        {
            _contexto = dbContext;
        }


        public IEnumerable<Publicacion> GetAll()
        {
            IEnumerable<Publicacion> publicaciones = _contexto.Set<Publicacion>()
                                        .Include(r=>r.Editorial)
                                        .Include(r=>r.Tema);
            return publicaciones;
        }
        
       
    }
}
