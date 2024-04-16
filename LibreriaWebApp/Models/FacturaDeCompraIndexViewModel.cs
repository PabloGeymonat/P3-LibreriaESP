using System.ComponentModel.DataAnnotations;
using Domain.Dtos;
using Domain.Models;

namespace LibreriaWebApp.Models;

public class FacturaDeCompraIndexViewModel
{
        public string TipoReporte { get; set; }
        public int ProveedorId { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime FechaDeCompraDesde { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime FechaDeCompraHasta { get; set; }
        
        public int PublicacionId { get; set; }
        
        public IEnumerable<FacturaDeCompraDto> FacturaDeCompraDtos { get; set; }
        public IEnumerable<ProveedorDto> ProveedorDtos { get; set; }
        public IEnumerable<PublicacionDto> PublicacionDtos { get; set; }
        
        

}