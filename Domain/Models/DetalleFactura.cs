namespace Domain.Models;

public class DetalleFactura
{
    public int Id { get; set; }
    public int FacturaDeCompraId { get; set; }
    public FacturaDeCompra FacturaDeCompra { get; set; }
    public int PublicacionId { get; set; }
    public Publicacion Publicacion { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}