
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace DataAccess
{
    public class RepositorioFacturaDeCompra : Repository<FacturaDeCompra>, IRepositoryFacturaDeCompra
    {
        public RepositorioFacturaDeCompra(DbContext dbContext) 
        {
            contexto = dbContext;
        }


        public IEnumerable<FacturaDeCompra> GetByProveedor(int proveedorId)
        {
            return contexto.Set<FacturaDeCompra>()
                .Include(f=>f.Proveedor)
                .Where(f => f.Proveedor.Id == proveedorId);
        }

        public IEnumerable<FacturaDeCompra> GetFechaCompraBetwenDates(DateTime desde, DateTime hasta)
        {
            return contexto.Set<FacturaDeCompra>()
                .Include(f=>f.Proveedor)
                .Where(f => f.FechaCompra >= desde)
                .Where(f => f.FechaCompra <= hasta);
            
        }

        public IEnumerable<FacturaDeCompra> GetByPublicacion(int publicacionId)
        {
            return contexto.Set<FacturaDeCompra>()
                .Include(f => f.Proveedor)
                .Where(f => f.DetallesCompra.Any(d => d.Publicacion.Id == publicacionId)
                );
        }
    }
}
