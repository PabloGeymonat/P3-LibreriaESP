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
            _asignarTemasYEditorialesAViewModel(revistaFormViewModel);
            return revistaFormViewModel;
        }
        

        [HttpGet]
        public ActionResult Create()
        {
            return View(GetDefaultRevistaFormViewModel());
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RevistaFormViewModel revistaFormViewModel)
        {
            try
            {
                RevistaDto revistaDto = revistaFormViewModel.ToRevistaDto();
                _servicioRevista.Add(revistaDto);
                return RedirectToAction(nameof(Index));
                
            }
            catch(Exception e)
            {
                ViewBag.Message = e.ToString(); 
                _asignarTemasYEditorialesAViewModel(revistaFormViewModel);
                return View(revistaFormViewModel);
            }
        }

        private void _asignarTemasYEditorialesAViewModel(RevistaFormViewModel revistaFormViewModel)
        {
            revistaFormViewModel.posiblesTemas = _servicioTema.GetByName("");
            revistaFormViewModel.posiblesEditoriales = _servicioEditorial.GetByName("");
        }


        private RevistaFormViewModel _obtenerViewModelDeUnIdDeRevista(int id)
        {
            RevistaDto revistaDto = _servicioRevista.Get(id);
            RevistaFormViewModel revistaFormViewModel = new RevistaFormViewModel(revistaDto);
            _asignarTemasYEditorialesAViewModel(revistaFormViewModel);
            return revistaFormViewModel;
        }

        public ActionResult Edit(int id)
        {
            RevistaFormViewModel revistaFormViewModel = _obtenerViewModelDeUnIdDeRevista(id);
            return View(revistaFormViewModel);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RevistaFormViewModel revistaFormViewModel)
        {
            try
            {
                RevistaDto revistaDto = revistaFormViewModel.ToRevistaDto();
                _servicioRevista.Update(id, revistaDto);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message; 
                revistaFormViewModel = _obtenerViewModelDeUnIdDeRevista(id);
                return View(revistaFormViewModel);
            }
        }

        
        public ActionResult Delete(int id)
        {
            RevistaDto revistaDto = _servicioRevista.Get(id);
            RevistaFormViewModel revistaFormViewModel = new RevistaFormViewModel(revistaDto);
            return View(revistaFormViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, RevistaFormViewModel revistaFormViewModel)
        {
            try
            {
                _servicioRevista.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message; 
                revistaFormViewModel = _obtenerViewModelDeUnIdDeRevista(id);
                return View(revistaFormViewModel);
            }
        }
    }
}
