using Domain.Dtos;
using Domain.Exceptions;
using LibreriaWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using UsesCases;

namespace LibreriaWebApp.Controllers
{
    public class LibroController : Controller
    {

        private IServicioLibro _servicioLibro;
        private IServicioTema _servicioTema;
        private IServicioEditorial _servicioEditorial;
        
        public LibroController(IServicioLibro servicioLibro, 
                                IServicioTema servicioTema,
                                IServicioEditorial servicioEditorial)
        {
            _servicioLibro = servicioLibro;
            _servicioTema = servicioTema;
            _servicioEditorial = servicioEditorial;
        }

        public ActionResult Index()
        {
            IEnumerable<LibroDto> LibroDtos = _servicioLibro.GetByISBN("");
            LibroIndexViewModel LibroIndexViewModel = new LibroIndexViewModel()
            {
                Libros = LibroDtos
            };
            return View(LibroIndexViewModel);
        }

        private LibroFormViewModel GetDefaultLibroFormViewModel()
        {
            LibroFormViewModel LibroFormViewModel = new LibroFormViewModel();
            LibroFormViewModel.posiblesTemas = _servicioTema.GetByName("");
            LibroFormViewModel.posiblesEditoriales = _servicioEditorial.GetByName("");
            return LibroFormViewModel;
        }
        

        [HttpGet]
        public ActionResult Create()
        {
            return View(GetDefaultLibroFormViewModel());
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LibroFormViewModel libroFormViewModel)
        {
            try
            {
                LibroDto libroDto = libroFormViewModel.ToLibroDto();
                _servicioLibro.Add(libroDto);
                return RedirectToAction(nameof(Index));
                
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message;
                _asignarTemasYEditorialesAViewModel(libroFormViewModel);
                return View(libroFormViewModel);
            }
        }

       
        public ActionResult Edit(int id)
        {
            LibroFormViewModel libroFormViewModel = _obtenerViewModelDeUnIdDeLibro(id);
            return View(libroFormViewModel);
        }

        
        private LibroFormViewModel _obtenerViewModelDeUnIdDeLibro(int id)
        {
            LibroDto libroDto = _servicioLibro.Get(id);
            LibroFormViewModel libroFormViewModel = new LibroFormViewModel(libroDto);
            _asignarTemasYEditorialesAViewModel(libroFormViewModel);
            return libroFormViewModel;
        }
        
        public void _asignarTemasYEditorialesAViewModel(LibroFormViewModel libroFormViewModel)
        {
            libroFormViewModel.posiblesTemas = _servicioTema.GetByName("");
            libroFormViewModel.posiblesEditoriales = _servicioEditorial.GetByName("");
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LibroFormViewModel libroFormViewModel)
        {
            try
            {
                LibroDto LibroDto = libroFormViewModel.ToLibroDto();
                _servicioLibro.Update(id, LibroDto);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message;
                libroFormViewModel = _obtenerViewModelDeUnIdDeLibro(id);
                return View(libroFormViewModel);
            }
        }

        
        public ActionResult Delete(int id)
        {
            LibroFormViewModel libroFormViewModel =_obtenerViewModelDeUnIdDeLibro(id);
            return View(libroFormViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LibroDto libroDto)
        {
            try
            {
                _servicioLibro.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message; 
                LibroFormViewModel libroFormViewModel =_obtenerViewModelDeUnIdDeLibro(id);
                return View(libroFormViewModel);
            }
        }
    }
}
