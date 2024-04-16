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
    public decimal IvaAplicado { get; set; }

    public decimal GetSubTotalSinImpuestos()
    {
        return PrecioUnitario * Cantidad;
    }
    
    public decimal GetSubTotalConImpuestos()
    {
        return GetSubTotalSinImpuestos() + (1 + (IvaAplicado / 100));
    }
    
    public decimal GetMontoDeImpuestos()
    {
        return GetSubTotalConImpuestos() - GetSubTotalSinImpuestos();
    }
}