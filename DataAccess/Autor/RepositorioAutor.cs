
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace DataAccess
{
    public class RepositorioAutor : Repository<Autor>, IRepositoryAutor
    {
        public RepositorioAutor(DbContext dbContext) 
        {
            Contexto = dbContext;
        }


        public IEnumerable<Autor> GetByName(string name)
        {
            IEnumerable<Autor> autores = Contexto.Set<Autor>()
                                        .Include(n =>n.Nacionalidad)
                                        .Where(autor => autor.Nombre.Contains(name));
            
            return autores;
        }

        public IEnumerable<Autor> GetFechaDeNacimentoEntreDosFechas(DateTime desde, DateTime hasta)
        {
            IEnumerable<Autor> autores = Contexto.Set<Autor>()
                .Include(n =>n.Nacionalidad)
                .Where(autor =>  autor.FechaNacimiento >=  desde && autor.FechaNacimiento <= hasta);
            
            return autores;   
        }

        public IEnumerable<Autor> GetFechaDeFallecimientoEntreDosFechas(DateTime desde, DateTime hasta)
        {
            IEnumerable<Autor> autores = Contexto.Set<Autor>()
                .Include(n =>n.Nacionalidad)
                .Where(autor =>  autor.FechaDefuncion >=  desde && autor.FechaDefuncion <= hasta);
            
            return autores; 
        }

        public IEnumerable<Autor> GetNacionalidad(int nacionalidadId)
        {
            IEnumerable<Autor> autores = Contexto.Set<Autor>()
                .Include(n =>n.Nacionalidad)
                .Where(autor => autor.Nacionalidad.Id == nacionalidadId);
            return autores;
        }

        public override Autor Get(int id)
        {
            Autor autor = Contexto.Set<Autor>()
                            .Include(n =>n.Nacionalidad)
                            .FirstOrDefault(e => e.Id == id);
                
            return autor;
        }
    }
}
