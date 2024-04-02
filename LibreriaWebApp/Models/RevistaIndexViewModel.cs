using Domain.Dtos;
using Domain.Models;

namespace LibreriaWebApp.Models;

public class RevistaIndexViewModel
{
        public string nombre { get; set; }
        public IEnumerable<RevistaDto> Revistaes { get; set; }

}