using Domain.Dtos;
using Domain.Exceptions;
using LibreriaWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using UsesCases;

namespace LibreriaWebApp.Controllers
{
    public class RevistaController : Controller
    {

        private IServicioRevista _servicioRevista;
        private IServicioTema _servicioTema;
        private IServicioEditorial _servicioEditorial;
        
        public RevistaController(IServicioRevista servicioRevista, 
                                IServicioTema servicioTema,
                                IServicioEditorial servicioEditorial)
        {
            _servicioRevista = servicioRevista;
            _servicioTema = servicioTema;
            _servicioEditorial = servicioEditorial;
        }

        public ActionResult Index()
        {
            IEnumerable<RevistaDto> RevistaDtos = _servicioRevista.GetByName("");
            RevistaIndexViewModel RevistaIndexViewModel = new RevistaIndexViewModel()
            {
                Revistaes = RevistaDtos
            };
            return View(RevistaIndexViewModel);
        }

        private RevistaFormViewModel GetDefaultRevistaFormViewModel()
        {
            RevistaFormViewModel revistaFormViewModel = new RevistaFormViewModel();
            revistaFormViewModel.posiblesTemas = _servicioTema.GetByName("");
            revistaFormViewModel.posiblesEditoriales = _servicioEditorial.GetByName("");
            return revistaFormViewModel;
        }
        

        [HttpGet]
        public ActionResult Create()
        {
            return View(GetDefaultRevistaFormViewModel());
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RevistaFormViewModel RevistaFormViewModel)
        {
            try
            {
                RevistaDto RevistaDto = RevistaFormViewModel.ToRevistaDto();
                _servicioRevista.Add(RevistaDto);
                return RedirectToAction(nameof(Index));
                
            }
            catch(Exception e)
            {
                ViewBag.Message = e.ToString(); 
                return View(RevistaFormViewModel);
            }
        }

       
        public ActionResult Edit(int id)
        {
            RevistaDto RevistaDto = _servicioRevista.Get(id);
            RevistaFormViewModel revistaFormViewModel = new RevistaFormViewModel(RevistaDto);
            revistaFormViewModel.posiblesTemas = _servicioTema.GetByName("");
            revistaFormViewModel.posiblesEditoriales = _servicioEditorial.GetByName("");
            return View(revistaFormViewModel);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RevistaFormViewModel RevistaFormViewModel)
        {
            try
            {
                RevistaDto RevistaDto = RevistaFormViewModel.ToRevistaDto();
                _servicioRevista.Update(id, RevistaDto);
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
            RevistaDto RevistaDto = _servicioRevista.Get(id);
            RevistaFormViewModel RevistaFormViewModel = new RevistaFormViewModel(RevistaDto);
            return View(RevistaFormViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, RevistaDto RevistaDto)
        {
            try
            {
                _servicioRevista.Remove(id);
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
