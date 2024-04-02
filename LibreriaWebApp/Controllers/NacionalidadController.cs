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
            IEnumerable<NacionalidadDto> NacionalidadesDto = _servicioNacionalidad.GetByName("");
            NacionalidadViewModel NacionalidadViewModel = new NacionalidadViewModel()
            {
                Nacionalidades = NacionalidadesDto
            };
            return View(NacionalidadViewModel);
        }

        [HttpPost]
        public ActionResult Index(NacionalidadViewModel NacionalidadViewModel)
        {
            string nombre = "" + NacionalidadViewModel.nombre;
            IEnumerable<NacionalidadDto> NacionalidadesDto = _servicioNacionalidad.GetByName(nombre);
            NacionalidadViewModel.Nacionalidades = NacionalidadesDto;
            return View(NacionalidadViewModel);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NacionalidadDto NacionalidadDto)
        {
            try
            {
                NacionalidadDto newNacionalidadDto = _servicioNacionalidad.Add(NacionalidadDto);
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
        public ActionResult Edit(int id, NacionalidadDto NacionalidadDto)
        {
            try
            {
                _servicioNacionalidad.Update(id, NacionalidadDto);
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
            NacionalidadDto NacionalidadDto = _servicioNacionalidad.Get(id);
            return View(NacionalidadDto);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, NacionalidadDto NacionalidadDto)
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
