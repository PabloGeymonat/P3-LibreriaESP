
using AutoMapper;
using DataAccess;
using Domain.Dtos;
using Domain.Models;

using Bogus;

namespace UsesCases
{
    public class ServicioFacturaDeCompra : ServicioCRUD<FacturaDeCompra, FacturaDeCompraDto> , IServicioFacturaDeCompra
    {
        private IRepositoryFacturaDeCompra _repository;
        public ServicioFacturaDeCompra(IMapper mapper, IRepositoryFacturaDeCompra repository) : base(mapper, repository)
        {
            _repository = repository;
        }


        public IEnumerable<FacturaDeCompraDto> GetByProveedor(int proveedorId)
        {
            IEnumerable<FacturaDeCompra> facturaDeCompras = _repository.GetByProveedor(proveedorId);
            IEnumerable<FacturaDeCompraDto> facturaDeCompraDtos = _mapper.Map<IEnumerable<FacturaDeCompraDto>>(facturaDeCompras);
            return facturaDeCompraDtos;
        }

        public IEnumerable<FacturaDeCompraDto> GetFechaCompraBetwenDates(DateTime desde, DateTime hasta)
        {
            IEnumerable<FacturaDeCompra> facturaDeCompras = _repository.GetFechaCompraBetwenDates(desde, hasta);
            IEnumerable<FacturaDeCompraDto> facturaDeCompraDtos = _mapper.Map<IEnumerable<FacturaDeCompraDto>>(facturaDeCompras);
            return facturaDeCompraDtos;
        }

        public IEnumerable<FacturaDeCompraDto> GetByPublicacion(int publicacionId)
        {
            IEnumerable<FacturaDeCompra> facturaDeCompras = _repository.GetByPublicacion(publicacionId);
            IEnumerable<FacturaDeCompraDto> facturaDeCompraDtos = _mapper.Map<IEnumerable<FacturaDeCompraDto>>(facturaDeCompras);
            return facturaDeCompraDtos;
        }

        public void GenerateFacturasDeCompraDePrueba()
        {


            // Primero definimos y configuramos el Faker para los detalles de la factura
            var detalleFaker = new Faker<DetalleFactura>()
                .RuleFor(o => o.PublicacionId, f => f.PickRandom(new[] { 1, 2 }))  // Rotación entre 1, 2 y 3
                .RuleFor(o => o.Cantidad, f => f.Random.Int(1, 20))
                .RuleFor(o => o.PrecioUnitario, f => f.Random.Decimal(50, 200))
                .RuleFor(o => o.IvaAplicado, f => f.Random.ArrayElement(new decimal[] { 0, 5, 10, 15 }));

            var facturaFaker = new Faker<FacturaDeCompra>()
                .RuleFor(o => o.ProveedorId, f => f.PickRandom(new[] { 1, 2 }))  // Proveedor fijo
                .RuleFor(o => o.FechaCompra, f => f.Date.Recent(90))
                .RuleFor(o => o.VencimientoPago, (f, o) => o.FechaCompra.AddDays(30))
                .RuleFor(o => o.DetallesCompra, f => detalleFaker.Generate(3)) 
                .FinishWith((f, o) =>
                {
                    o.SubTotal = o.DetallesCompra.Sum(d => d.GetSubTotalSinImpuestos());
                    o.Impuestos = o.DetallesCompra.Sum(d => d.GetMontoDeImpuestos());
                    o.Total = o.SubTotal + o.Impuestos;
                });


            // Generar 100 facturas
            List<FacturaDeCompra> facturas = facturaFaker.Generate(100);



            // Impresión de los resultados para verificar
            foreach (var factura in facturas)
            {
                Console.WriteLine($"Factura ID: {factura.Id}, Proveedor ID: {factura.ProveedorId}");
                Console.WriteLine($"Fecha Compra: {factura.FechaCompra}, Vencimiento Pago: {factura.VencimientoPago}");
                Console.WriteLine($"SubTotal: {factura.SubTotal}, Impuestos: {factura.Impuestos}, Total: {factura.Total}");
                foreach (var detalle in factura.DetallesCompra)
                {
                    Console.WriteLine($"  Detalle - Publicación ID: {detalle.PublicacionId}, Cantidad: {detalle.Cantidad}, Precio Unitario: {detalle.PrecioUnitario}, IVA Aplicado: {detalle.IvaAplicado}");
                    Console.WriteLine($"  SubTotal Sin Impuestos: {detalle.GetSubTotalSinImpuestos()}, SubTotal Con Impuestos: {detalle.GetSubTotalConImpuestos()}, Monto de Impuestos: {detalle.GetMontoDeImpuestos()}");
                }
                Console.WriteLine();
                _repository.Add(factura);
            }
            

        }
    }
}