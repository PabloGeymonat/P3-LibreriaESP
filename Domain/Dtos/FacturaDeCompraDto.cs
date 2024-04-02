namespace Domain.Dtos;

public class FacturaDeCompraDto
{
    public int Id { get; set; }
    public int ProveedorId { get; set; }
    public ProveedorDto ProveedorDto { get; set; }
    public DateTime FechaCompra { get; set; }
    public DateTime VencimientoPago { get; set; }
    public List<DetalleFacturaDto> DetallesCompra { get; set; } = new List<DetalleFacturaDto>();
    
    
    public decimal SubTotal { get; set; } //=> DetallesCompra.Sum(dc => dc.Cantidad * dc.PrecioUnitario);
    public decimal Impuestos { get; set; }
    public decimal Total { get; set; } //=> SubTotal + Impuestos;
}