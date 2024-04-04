using Domain.Dtos;
using Domain.Exceptions;
using LibreriaWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using UsesCases;

namespace LibreriaWebApp.Controllers
{
    public class TemaController : Controller
    {

        private IServicioTema _servicioTema;
        
        public TemaController(IServicioTema servicioTema)
        {
            _servicioTema = servicioTema;
        }

        public ActionResult Index()
        {
            IEnumerable<TemaDto> temaDtos = _servicioTema.GetByName("");
            TemaIndexViewModel temaIndexViewModel = new TemaIndexViewModel()
            {
                Temas = temaDtos
            };
            return View(temaIndexViewModel);
        }

        [HttpPost]
        public ActionResult Index(TemaIndexViewModel temaIndexViewModel)
        {
            string nombre = "" + temaIndexViewModel.nombre;
            IEnumerable<TemaDto> temaDtos = _servicioTema.GetByName(nombre);
            temaIndexViewModel.Temas = temaDtos;
            return View(temaIndexViewModel);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TemaDto temaDto)
        {
            try
            {
                TemaDto newTemaDto = _servicioTema.Add(temaDto);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message; 
                return View(temaDto);
            }
        }

       
        public ActionResult Edit(int id)
        {
            TemaDto temaDto = _servicioTema.Get(id);
            return View(temaDto);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TemaDto temaDto)
        {
            try
            {
                _servicioTema.Update(id, temaDto);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message; 
                return View(temaDto);
            }
        }

        
        public ActionResult Delete(int id)
        {
            TemaDto temaDto = _servicioTema.Get(id);
            return View(temaDto);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TemaDto temaDto)
        {
            try
            {
                _servicioTema.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message; 
                return View(temaDto);
            }
        }
    }
}
