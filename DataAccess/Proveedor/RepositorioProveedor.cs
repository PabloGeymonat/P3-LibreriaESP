
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace DataAccess
{
    public class RepositorioProveedor : Repository<Proveedor>, IRepositoryProveedor
    {
        public RepositorioProveedor(DbContext dbContext) 
        {
            Contexto = dbContext;
        }


        public IEnumerable<Proveedor> GetByName(string nombre)
        {
            IEnumerable<Proveedor> Proveedors = Contexto.Set<Proveedor>()
                                        .Where(Proveedor => Proveedor.Nombre.Contains(nombre));
            return Proveedors;
        }
    }
}
