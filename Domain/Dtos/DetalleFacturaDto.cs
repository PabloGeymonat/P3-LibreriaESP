namespace Domain.Dtos;

public class DetalleFacturaDto
{
    public int Id { get; set; }
    public FacturaDeCompraDto FacturaDeCompraDto { get; set; }
    public PublicacionDto PublicacionDto { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}