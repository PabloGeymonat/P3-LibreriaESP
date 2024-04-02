using Domain.Dtos;
using Domain.Exceptions;
using LibreriaWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using UsesCases;

namespace LibreriaWebApp.Controllers
{
    public class EditorialController : Controller
    {

        private IServicioEditorial _servicioEditorial;
        private IServicioPais _servicioPais;
        
        public EditorialController(IServicioEditorial servicioEditorial, 
                                        IServicioPais servicioPais)
        {
            _servicioEditorial = servicioEditorial;
            _servicioPais = servicioPais;
        }

        public ActionResult Index()
        {
            IEnumerable<EditorialDto> editorialDtos = _servicioEditorial.GetByName("");
            EditorialIndexViewModel EditorialIndexViewModel = new EditorialIndexViewModel()
            {
                EditorialesDto = editorialDtos
            };
            return View(EditorialIndexViewModel);
        }

        [HttpPost]
        public ActionResult Index(EditorialIndexViewModel EditorialIndexViewModel)
        {
            IEnumerable<EditorialDto> EditorialDtos;
            EditorialDtos = _servicioEditorial.GetByName("" + EditorialIndexViewModel.Nombre);
            EditorialIndexViewModel.EditorialesDto = EditorialDtos;
            return View(EditorialIndexViewModel);
        }


        private EditorialFormViewModel GetDefaultEditorialFormViewModel()
        {
            EditorialFormViewModel EditorialFormViewModel = new EditorialFormViewModel();
            EditorialFormViewModel.posiblesPaises = _servicioPais.GetByName("");
            return EditorialFormViewModel;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(GetDefaultEditorialFormViewModel());
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EditorialFormViewModel EditorialFormViewModel)
        {
            try
            {
                EditorialDto EditorialDto = EditorialFormViewModel.ToEditorialDto();
                _servicioEditorial.Add(EditorialDto);
                return RedirectToAction(nameof(Index));
                
            }
            catch(Exception e)
            {
                ViewBag.Message = e.ToString(); 
                return View(EditorialFormViewModel);
            }
        }

       
        public ActionResult Edit(int id)
        {
            EditorialDto EditorialDto = _servicioEditorial.Get(id);
            EditorialFormViewModel EditorialFormViewModel = new EditorialFormViewModel(EditorialDto);
            EditorialFormViewModel.posiblesPaises = _servicioPais.GetByName("");
            return View(EditorialFormViewModel);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditorialFormViewModel EditorialFormViewModel)
        {
            try
            {
                EditorialDto EditorialDto = EditorialFormViewModel.ToEditorialDto();
                _servicioEditorial.Update(id, EditorialDto);
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
            EditorialDto EditorialDto = _servicioEditorial.Get(id);
            EditorialFormViewModel EditorialFormViewModel = new EditorialFormViewModel(EditorialDto);
            return View(EditorialFormViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EditorialDto EditorialDto)
        {
            try
            {
                _servicioEditorial.Remove(id);
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
