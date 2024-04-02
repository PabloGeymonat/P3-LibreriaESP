using Domain.Dtos;
using Domain.Models;

namespace LibreriaWebApp.Models;

public class AutorIndexViewModel
{
        public string TipoReporte { get; set; }
        public string nombre { get; set; }
        public DateTime FechaNacimientoDesde { get; set; }
        public DateTime FechaNacimientoHasta { get; set; }
        
        public DateTime FechaDefuncionDesde { get; set; }
        public DateTime FechaDefuncionHasta { get; set; }
        
        public Nacionalidad Nacionalidad { get; set; }
        public IEnumerable<AutorDto> Autores { get; set; }
        
        

}