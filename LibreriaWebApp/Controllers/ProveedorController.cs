using Domain.Dtos;
using Domain.Exceptions;
using Domain.Models;
using LibreriaWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using UsesCases;

namespace LibreriaWebApp.Controllers
{
    public class ProveedorController : Controller
    {

        private IServicioProveedor _servicioProveedor;
        public ProveedorController(IServicioProveedor servicioProveedor)
        {
            _servicioProveedor = servicioProveedor;
        }

        public ActionResult Index()
        {
            IEnumerable<ProveedorDto> ProveedoresDto = _servicioProveedor.GetByName("");
            ProveedorIndexViewModel ProveedorIndexViewModel = new ProveedorIndexViewModel()
            {
                Proveedores = ProveedoresDto
            };
            return View(ProveedorIndexViewModel);
        }

        [HttpPost]
        public ActionResult Index(ProveedorIndexViewModel ProveedorIndexViewModel)
        {
            string nombre = "" + ProveedorIndexViewModel.nombre;
            IEnumerable<ProveedorDto> ProveedoresDto = _servicioProveedor.GetByName(nombre);
            ProveedorIndexViewModel.Proveedores = ProveedoresDto;
            return View(ProveedorIndexViewModel);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProveedorDto ProveedorDto)
        {
            try
            {
                ProveedorDto newProveedorDto = _servicioProveedor.Add(ProveedorDto);
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
            ProveedorDto ProveedorDto = _servicioProveedor.Get(id);
            return View(ProveedorDto);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProveedorDto ProveedorDto)
        {
            try
            {
                _servicioProveedor.Update(id, ProveedorDto);
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
            ProveedorDto ProveedorDto = _servicioProveedor.Get(id);
            return View(ProveedorDto);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProveedorDto ProveedorDto)
        {
            try
            {
                _servicioProveedor.Remove(id);
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
