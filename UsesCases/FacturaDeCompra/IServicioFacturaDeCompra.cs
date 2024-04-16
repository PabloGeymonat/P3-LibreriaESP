using Domain.Dtos;
using Domain.Models;

namespace UsesCases
{

    public interface IServicioFacturaDeCompra : IServicioCRUD<FacturaDeCompraDto>
    {
        IEnumerable<FacturaDeCompraDto> GetByProveedor(int proveedorId);
        IEnumerable<FacturaDeCompraDto> GetFechaCompraBetwenDates(DateTime desde, DateTime hasta);
        IEnumerable<FacturaDeCompraDto> GetByPublicacion(int publicacionId);


        void GenerateFacturasDeCompraDePrueba();
    }
}