using Domain.Dtos;

namespace LibreriaWebApp.Models;

public class ParametroIndexViewModel
{
        public string Clave { get; set; }
        public IEnumerable<ParametroDto> Parametros { get; set; }

}