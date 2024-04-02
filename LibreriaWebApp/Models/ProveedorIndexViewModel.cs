using Domain.Dtos;
using Domain.Models;

namespace LibreriaWebApp.Models;

public class ProveedorIndexViewModel
{
        public string nombre { get; set; }
        public IEnumerable<ProveedorDto> Proveedores { get; set; }

}