
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace DataAccess
{
    public class RepositorioProveedor : Repository<Proveedor>, IRepositoryProveedor
    {
        public RepositorioProveedor(DbContext dbContext) 
        {
            contexto = dbContext;
        }


        public IEnumerable<Proveedor> GetByName(string nombre)
        {
            IEnumerable<Proveedor> Proveedors = contexto.Set<Proveedor>()
                                        .Where(Proveedor => Proveedor.Nombre.Contains(nombre));
            return Proveedors;
        }
    }
}
