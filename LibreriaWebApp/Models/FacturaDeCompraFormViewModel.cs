using Domain.Dtos;


namespace LibreriaWebApp.Models;

public class FacturaDeCompraFormViewModel
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
    
    public IEnumerable<ProveedorDto> posiblesProveedores { get; set; }
    public IEnumerable<PublicacionDto> posiblesPublicaciones { get; set; }
    
    public DetalleFacturaDto NewLine { get; set; } = new DetalleFacturaDto();
    public FacturaDeCompraFormViewModel()
    {
    }

    public FacturaDeCompraFormViewModel(FacturaDeCompraDto facturaDeCompraDto)
    {
        Id = facturaDeCompraDto.Id;
        ProveedorId = facturaDeCompraDto.ProveedorDto.Id;
        ProveedorDto = facturaDeCompraDto.ProveedorDto;
        FechaCompra = facturaDeCompraDto.FechaCompra;
        VencimientoPago = facturaDeCompraDto.VencimientoPago;
        DetallesCompra = facturaDeCompraDto.DetallesCompra;
        SubTotal = facturaDeCompraDto.SubTotal;
        Impuestos = facturaDeCompraDto.Impuestos;
        Total = facturaDeCompraDto.Total;
    }

    public FacturaDeCompraDto ToFacturaDeCompraDto()
    {
        FacturaDeCompraDto facturaDeCompraDto = new FacturaDeCompraDto()
        {
            Id = Id,
            ProveedorId = ProveedorDto.Id,
            ProveedorDto = ProveedorDto,
            FechaCompra = FechaCompra,
            VencimientoPago = VencimientoPago,
            DetallesCompra = DetallesCompra,
            SubTotal = SubTotal,
            Impuestos = Impuestos,
            Total = Total
        };
        return facturaDeCompraDto;
    }
   
}