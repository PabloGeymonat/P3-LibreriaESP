using Domain.Dtos;
using Domain.Exceptions;
using Domain.Models;
using LibreriaWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using UsesCases;

namespace LibreriaWebApp.Controllers
{
    public class PaisController : Controller
    {

        private IServicioPais _servicioPais;
        public PaisController(IServicioPais servicioPais)
        {
            _servicioPais = servicioPais;
        }

        public ActionResult Index()
        {
            IEnumerable<PaisDto> paisesDto = _servicioPais.GetByName("");
            PaisIndexViewModel paisIndexViewModel = new PaisIndexViewModel()
            {
                Paises = paisesDto
            };
            return View(paisIndexViewModel);
        }

        [HttpPost]
        public ActionResult Index(PaisIndexViewModel paisIndexViewModel)
        {
            string nombre = "" + paisIndexViewModel.nombre;
            IEnumerable<PaisDto> paisesDto = _servicioPais.GetByName(nombre);
            paisIndexViewModel.Paises = paisesDto;
            return View(paisIndexViewModel);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaisDto paisDto)
        {
            try
            {
                PaisDto newPaisDto = _servicioPais.Add(paisDto);
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
            PaisDto PaisDto = _servicioPais.Get(id);
            return View(PaisDto);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PaisDto paisDto)
        {
            try
            {
                _servicioPais.Update(id, paisDto);
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
            PaisDto paisDto = _servicioPais.Get(id);
            return View(paisDto);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PaisDto paisDto)
        {
            try
            {
                _servicioPais.Remove(id);
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
