using Domain.Dtos;
using Domain.Exceptions;
using LibreriaWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using UsesCases;

namespace LibreriaWebApp.Controllers
{
    public class AutorController : Controller
    {

        private IServicioAutor _servicioAutor;
        private IServicioNacionalidad _servicioAutoNacionalidad;
        
        public AutorController(IServicioAutor servicioAutor, 
                                IServicioNacionalidad servicioNacionalidad)
        {
            _servicioAutor = servicioAutor;
            _servicioAutoNacionalidad = servicioNacionalidad;
        }

        public ActionResult Index()
        {
            IEnumerable<AutorDto> AutorDtos = _servicioAutor.GetByName("");
            AutorIndexViewModel autorIndexViewModel = new AutorIndexViewModel()
            {
                Autores = AutorDtos,
                NacionalidadDtos = _servicioAutoNacionalidad.GetByName("")
            };
            return View(autorIndexViewModel);
        }

        [HttpPost]
        public ActionResult Index(AutorIndexViewModel autorIndexViewModel)
        {
            IEnumerable<AutorDto> autorDtos;
            switch (autorIndexViewModel.TipoReporte)
            {
                case "POR_NOMBRE":
                    autorDtos = _servicioAutor.GetByName("" + autorIndexViewModel.nombre);
                    break;
                case "POR_NACIONALIDAD":
                   autorDtos = _servicioAutor.GetNacionalidad(autorIndexViewModel.NacionalidadId);
                    break;
                case "POR_FECHA_DE_NACIMIENTO":
                    autorDtos = _servicioAutor.GetFechaDeNacimentoEntreDosFechas(autorIndexViewModel.FechaNacimientoDesde, autorIndexViewModel.FechaNacimientoHasta);
                    break;
                case "POR_FECHA_DE_DEFUNCION":
                    autorDtos = _servicioAutor.GetFechaDeFallecimientoEntreDosFechas(autorIndexViewModel.FechaDefuncionDesde, autorIndexViewModel.FechaDefuncionHasta);
                    break;
                default:
                    autorDtos = _servicioAutor.GetByName("" + autorIndexViewModel.nombre);
                    break;
            }

            
            autorIndexViewModel.Autores = autorDtos;
            autorIndexViewModel.NacionalidadDtos = _servicioAutoNacionalidad.GetByName("");
            return View(autorIndexViewModel);
        }


        private AutorFormViewModel GetDefaultAutorFormViewModel()
        {
            AutorFormViewModel autorFormViewModel = new AutorFormViewModel();
            autorFormViewModel.posiblesNacionalidades = _servicioAutoNacionalidad.GetByName("");
            return autorFormViewModel;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(GetDefaultAutorFormViewModel());
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AutorFormViewModel autorFormViewModel)
        {
            try
            {
                AutorDto autorDto = autorFormViewModel.ToAutorDto();
                autorDto.NacionalidadDto = _servicioAutoNacionalidad.Get(autorFormViewModel.NacionalidadId);
                _servicioAutor.Add(autorDto);
                return RedirectToAction(nameof(Index));
                
            }
            catch(Exception e)
            {
                ViewBag.Message = e.ToString(); 
                return View(autorFormViewModel);
            }
        }

       
        public ActionResult Edit(int id)
        {
            AutorDto autorDto = _servicioAutor.Get(id);
            AutorFormViewModel autorFormViewModel = new AutorFormViewModel(autorDto);
            autorFormViewModel.posiblesNacionalidades = _servicioAutoNacionalidad.GetByName("");
            return View(autorFormViewModel);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AutorFormViewModel autorFormViewModel)
        {
            try
            {
                AutorDto autorDto = autorFormViewModel.ToAutorDto();
                _servicioAutor.Update(id, autorDto);
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
            AutorDto autorDto = _servicioAutor.Get(id);
            AutorFormViewModel autorFormViewModel = new AutorFormViewModel(autorDto);
            return View(autorFormViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AutorDto AutorDto)
        {
            try
            {
                _servicioAutor.Remove(id);
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
