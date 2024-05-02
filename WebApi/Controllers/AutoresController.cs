using Microsoft.AspNetCore.Mvc;
using UsesCases;
using Domain.Dtos;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {
       
        private readonly IServicioAutor _servicio;

        public AutoresController(IServicioAutor servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public  IActionResult Get()
        {
            IEnumerable<AutorDto> autores = _servicio.GetByName("");
            return Ok(autores);

        }
    }
}
