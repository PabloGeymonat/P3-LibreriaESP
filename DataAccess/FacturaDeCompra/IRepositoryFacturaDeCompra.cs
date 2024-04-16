using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DataAccess
{
    public interface IRepositoryFacturaDeCompra: IRepository<FacturaDeCompra>
    {
        IEnumerable<FacturaDeCompra> GetByProveedor(int proveedorId);
        IEnumerable<FacturaDeCompra> GetFechaCompraBetwenDates(DateTime desde, DateTime hasta);
        IEnumerable<FacturaDeCompra> GetByPublicacion(int publicacionId);
    }
}
