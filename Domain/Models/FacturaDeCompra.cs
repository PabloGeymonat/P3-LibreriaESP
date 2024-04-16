using Domain.Interfaces;

namespace Domain.Models;

public class FacturaDeCompra : IIdentityById, ICopiable<FacturaDeCompra>
{
    public int Id { get; set; }
    public int ProveedorId { get; set; }
    public Proveedor Proveedor { get; set; }
    public DateTime FechaCompra { get; set; }
    public DateTime VencimientoPago { get; set; }
    public List<DetalleFactura> DetallesCompra { get; set; } = new List<DetalleFactura>();
    
    
    public decimal SubTotal { get; set; } 
    public decimal Impuestos { get; set; }
    public decimal Total { get; set; }
    public void Copy(FacturaDeCompra model)
    {
        Proveedor = model.Proveedor;
        FechaCompra = model.FechaCompra;
        VencimientoPago = model.VencimientoPago;
    }


    public void CalcularTotales()
    {
        decimal subTotal = 0;
        decimal impuestos = 0;
        decimal total = 0;
        foreach (DetalleFactura detalleFactura in DetallesCompra)
        {
            subTotal += detalleFactura.GetSubTotalSinImpuestos();
            total += detalleFactura.GetSubTotalConImpuestos();
            impuestos += detalleFactura.GetMontoDeImpuestos();
        }

        SubTotal = subTotal;
        Total = total;
        Impuestos = impuestos;


    }

}