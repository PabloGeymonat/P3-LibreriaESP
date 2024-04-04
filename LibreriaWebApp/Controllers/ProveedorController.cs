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
            IEnumerable<ProveedorDto> proveedoresDto = _servicioProveedor.GetByName("");
            ProveedorIndexViewModel proveedorIndexViewModel = new ProveedorIndexViewModel()
            {
                Proveedores = proveedoresDto
            };
            return View(proveedorIndexViewModel);
        }

        [HttpPost]
        public ActionResult Index(ProveedorIndexViewModel proveedorIndexViewModel)
        {
            string nombre = "" + proveedorIndexViewModel.nombre;
            IEnumerable<ProveedorDto> proveedoresDto = _servicioProveedor.GetByName(nombre);
            proveedorIndexViewModel.Proveedores = proveedoresDto;
            return View(proveedorIndexViewModel);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProveedorDto proveedorDto)
        {
            try
            {
                ProveedorDto newProveedorDto = _servicioProveedor.Add(proveedorDto);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message; 
                return View(proveedorDto);
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
                return View(ProveedorDto);
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
