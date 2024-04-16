using Domain.Interfaces;

namespace Domain.Dtos;

public class FacturaDeCompraDto : IValidable
{
    public int Id { get; set; }
    public int ProveedorId { get; set; }
    public ProveedorDto ProveedorDto { get; set; }
    public DateTime FechaCompra { get; set; }
    public DateTime VencimientoPago { get; set; }
    public List<DetalleFacturaDto> DetallesCompra { get; set; } = new List<DetalleFacturaDto>();
    
    public decimal SubTotal { get; set; } 
    public decimal Impuestos { get; set; }
    public decimal Total { get; set; }
    public void Validar()
    {
        throw new NotImplementedException();
    }
}