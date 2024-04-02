using Domain.Dtos;

namespace LibreriaWebApp.Models;

public class TemaIndexViewModel
{
        public string nombre { get; set; }
        public IEnumerable<TemaDto> Temas { get; set; }

}