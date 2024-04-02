using Domain.Dtos;
using Domain.Models;

namespace LibreriaWebApp.Models;

public class PaisIndexViewModel
{
        public string nombre { get; set; }
        public IEnumerable<PaisDto> Paises { get; set; }

}