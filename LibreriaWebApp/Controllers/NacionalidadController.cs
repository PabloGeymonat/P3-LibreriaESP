using Domain.Dtos;
using Domain.Exceptions;
using Domain.Models;
using LibreriaWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using UsesCases;

namespace LibreriaWebApp.Controllers
{
    public class NacionalidadController : Controller
    {

        private IServicioNacionalidad _servicioNacionalidad;
        public NacionalidadController(IServicioNacionalidad servicioNacionalidad)
        {
            _servicioNacionalidad = servicioNacionalidad;
        }

        public ActionResult Index()
        {
            IEnumerable<NacionalidadDto> nacionalidadesDto = _servicioNacionalidad.GetByName("");
            NacionalidadViewModel nacionalidadViewModel = new NacionalidadViewModel()
            {
                Nacionalidades = nacionalidadesDto
            };
            return View(nacionalidadViewModel);
        }

        [HttpPost]
        public ActionResult Index(NacionalidadViewModel nacionalidadViewModel)
        {
            string nombre = "" + nacionalidadViewModel.nombre;
            IEnumerable<NacionalidadDto> nacionalidadesDto = _servicioNacionalidad.GetByName(nombre);
            nacionalidadViewModel.Nacionalidades = nacionalidadesDto;
            return View(nacionalidadViewModel);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NacionalidadDto nacionalidadDto)
        {
            try
            {
                NacionalidadDto newNacionalidadDto = _servicioNacionalidad.Add(nacionalidadDto);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message; 
                return View();
            }
        }

       
        public ActionResult Edit(int id)
        {
            NacionalidadDto NacionalidadDto = _servicioNacionalidad.Get(id);
            return View(NacionalidadDto);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NacionalidadDto nacionalidadDto)
        {
            try
            {
                _servicioNacionalidad.Update(id, nacionalidadDto);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message; 
                return View();
            }
        }

        
        public ActionResult Delete(int id)
        {
            NacionalidadDto nacionalidadDto = _servicioNacionalidad.Get(id);
            return View(nacionalidadDto);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, NacionalidadDto nacionalidadDto)
        {
            try
            {
                _servicioNacionalidad.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message; 
                return View();
            }
        }
    }
}
