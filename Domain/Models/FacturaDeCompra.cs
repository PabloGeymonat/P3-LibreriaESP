namespace Domain.Models;

public class FacturaDeCompra
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
}