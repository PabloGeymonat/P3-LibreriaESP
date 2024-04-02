using Domain.Dtos;
using Domain.Models;

namespace LibreriaWebApp.Models;

public class NacionalidadViewModel
{
        public string nombre { get; set; }
        public IEnumerable<NacionalidadDto> Nacionalidades { get; set; }

}