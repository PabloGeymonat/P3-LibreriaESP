
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
            IEnumerable<Autor> temas = Contexto.Set<Autor>()
                                        .Include(n =>n.Nacionalidad)
                                        .Where(tema => tema.Nombre.Contains(name));
            
            return temas;
        }

        public IEnumerable<Autor> GetFechaDeNacimentoEntreDosFechas(DateTime desde, DateTime hasta)
        {
            IEnumerable<Autor> temas = Contexto.Set<Autor>()
                .Include(n =>n.Nacionalidad)
                .Where(autor =>  autor.FechaNacimiento >=  desde && autor.FechaNacimiento <= hasta);
            
            return temas;   
        }

        public IEnumerable<Autor> GetFechaDeFallecimientoEntreDosFechas(DateTime desde, DateTime hasta)
        {
            IEnumerable<Autor> temas = Contexto.Set<Autor>()
                .Include(n =>n.Nacionalidad)
                .Where(autor =>  autor.FechaDefuncion >=  desde && autor.FechaDefuncion <= hasta);
            
            return temas; 
        }

        public IEnumerable<Autor> GetNacionalidad(Nacionalidad nacionalidad)
        {
            IEnumerable<Autor> temas = Contexto.Set<Autor>()
                .Include(n =>n.Nacionalidad)
                .Where(tema => tema.Nacionalidad.Equals(nacionalidad));
            
            return temas;
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
