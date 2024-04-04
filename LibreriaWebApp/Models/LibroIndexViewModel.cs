using Domain.Dtos;
using Domain.Models;

namespace LibreriaWebApp.Models;

public class LibroIndexViewModel
{
        public string ISBN { get; set; }
        public IEnumerable<LibroDto> Libros { get; set; }

}