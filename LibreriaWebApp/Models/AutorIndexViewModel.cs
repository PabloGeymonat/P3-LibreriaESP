using System.ComponentModel.DataAnnotations;
using Domain.Dtos;
using Domain.Models;

namespace LibreriaWebApp.Models;

public class AutorIndexViewModel
{
        public string TipoReporte { get; set; }
        public string nombre { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime FechaNacimientoDesde { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime FechaNacimientoHasta { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime FechaDefuncionDesde { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime FechaDefuncionHasta { get; set; }
        
        public int NacionalidadId { get; set; }
        public IEnumerable<AutorDto> Autores { get; set; }
        public IEnumerable<NacionalidadDto> NacionalidadDtos { get; set; }
        
        

}