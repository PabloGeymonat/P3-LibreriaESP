using Domain.Dtos;
using Domain.Exceptions;
using LibreriaWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using UsesCases;

namespace LibreriaWebApp.Controllers
{
    public class ParametroController : Controller
    {

        private IServicioParametro _servicioParametro;
        
        public ParametroController(IServicioParametro servicioParametro)
        {
            _servicioParametro = servicioParametro;
        }

        public ActionResult Index()
        {
            IEnumerable<ParametroDto> parametroDtos = _servicioParametro.GetManyByKey("");
            ParametroIndexViewModel parametroIndexViewModel = new ParametroIndexViewModel()
            {
                Parametros = parametroDtos
            };
            return View(parametroIndexViewModel);
        }

        [HttpPost]
        public ActionResult Index(ParametroIndexViewModel parametroIndexViewModel)
        {
            string nombre = "" + parametroIndexViewModel.Clave;
            IEnumerable<ParametroDto> parametroDtos = _servicioParametro.GetManyByKey(nombre);
            parametroIndexViewModel.Parametros = parametroDtos;
            return View(parametroIndexViewModel);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ParametroDto parametroDto)
        {
            try
            {
                _servicioParametro.Add(parametroDto);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message; 
                return View(parametroDto);
            }
        }

       
        public ActionResult Edit(string clave)
        {
            ParametroDto parametroDto = _servicioParametro.Get(clave);
            return View(parametroDto);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string clave, ParametroDto parametroDto)
        {
            try
            {
                _servicioParametro.Update(clave, parametroDto);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message; 
                return View(parametroDto);
            }
        }

        
        public ActionResult Delete(string clave)
        {
            ParametroDto parametroDto = _servicioParametro.Get(clave);
            return View(parametroDto);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string clave, ParametroDto parametroDto)
        {
            try
            {
                _servicioParametro.Remove(clave);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message; 
                return View(parametroDto);
            }
        }
    }
}
