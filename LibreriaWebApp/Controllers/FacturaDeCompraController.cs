using Domain.Dtos;
using LibreriaWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using UsesCases;
using Newtonsoft.Json;

namespace LibreriaWebApp.Controllers
{
    public class FacturaDeCompraController : Controller
    {
        private readonly int CANTIDAS_DIAS_X_DEFECTO_HACIA_ATRAS = -30;
        private readonly int CANTIDAS_DIAS_X_DEFECTO_HACIA_ADELANTE = 30;
        private IServicioFacturaDeCompra _servicioFacturaDeCompra;
        private IServicioProveedor _servicioProveedor;
        private IServicioPublicacion _servicioPublicacion;

        private static FacturaDeCompraFormViewModel _newFacturaDeCompraFormViewModel;
     
        public FacturaDeCompraController(IServicioFacturaDeCompra servicioFacturaDeCompra,
                                         IServicioProveedor servicioProveedor,
                                         IServicioPublicacion servicioPublicacion)
        {
            _servicioFacturaDeCompra = servicioFacturaDeCompra;
            _servicioProveedor = servicioProveedor;
            _servicioPublicacion = servicioPublicacion;
        }

        public ActionResult Index()
        {
            
            DateTime desde = DateTime.Today.AddDays(CANTIDAS_DIAS_X_DEFECTO_HACIA_ATRAS); //por defecto listo faturas de hace un mes 
            DateTime hasta = DateTime.Today.AddDays(CANTIDAS_DIAS_X_DEFECTO_HACIA_ADELANTE); //por defecto listo facturas hacia un mes adelante
            IEnumerable<FacturaDeCompraDto> facturaDeCompraDtos = _servicioFacturaDeCompra.GetFechaCompraBetwenDates(desde, hasta);
            FacturaDeCompraIndexViewModel facturaDeCompraIndexViewModel = new FacturaDeCompraIndexViewModel()
            {
                FacturaDeCompraDtos = facturaDeCompraDtos,
                ProveedorDtos = _servicioProveedor.GetByName(""),
                PublicacionDtos = _servicioPublicacion.GetAll()
            };
            return View(facturaDeCompraIndexViewModel);
        }


        [HttpGet]
        public ActionResult CreateFake()
        {
            try
            {
                _servicioFacturaDeCompra.GenerateFacturasDeCompraDePrueba();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Index(FacturaDeCompraIndexViewModel facturaDeCompraIndexViewModel)
        {
            IEnumerable<FacturaDeCompraDto> facturaDeCompraDtos = new List<FacturaDeCompraDto>();
            switch (facturaDeCompraIndexViewModel.TipoReporte)
            {
                case "POR_PROVEEDOR":
                    facturaDeCompraDtos = _servicioFacturaDeCompra.GetByProveedor(facturaDeCompraIndexViewModel.ProveedorId);
                    break;
                case "POR_FECHA_DE_COMPRA":
                    facturaDeCompraDtos = _servicioFacturaDeCompra.GetFechaCompraBetwenDates(facturaDeCompraIndexViewModel.FechaDeCompraDesde,
                                                                    facturaDeCompraIndexViewModel.FechaDeCompraHasta);
                    break;
                case "POR_PUBLICACION":
                    facturaDeCompraDtos = _servicioFacturaDeCompra.GetByPublicacion(facturaDeCompraIndexViewModel.PublicacionId);
                    break;
            }
            facturaDeCompraIndexViewModel = new FacturaDeCompraIndexViewModel();
            facturaDeCompraIndexViewModel.TipoReporte = "";
            facturaDeCompraIndexViewModel.FacturaDeCompraDtos = facturaDeCompraDtos;
            facturaDeCompraIndexViewModel.ProveedorDtos = _servicioProveedor.GetByName("");
            facturaDeCompraIndexViewModel.PublicacionDtos = _servicioPublicacion.GetAll();
            return View(facturaDeCompraIndexViewModel);
        }


        private FacturaDeCompraFormViewModel GetDefaultFacturaDeCompraFormViewModel()
        {
            FacturaDeCompraFormViewModel facturaDeCompraFormViewModel = new FacturaDeCompraFormViewModel();
            if (_newFacturaDeCompraFormViewModel != null)
            {
                facturaDeCompraFormViewModel = _newFacturaDeCompraFormViewModel;
               
            }
            facturaDeCompraFormViewModel.posiblesProveedores = _servicioProveedor.GetByName("");
            facturaDeCompraFormViewModel.posiblesPublicaciones = _servicioPublicacion.GetAll();
            return facturaDeCompraFormViewModel;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(GetDefaultFacturaDeCompraFormViewModel());
        }


        private FacturaDeCompraFormViewModel GetNewPedidoFromSession()
        {
            var objetoSerializado = HttpContext.Session.GetString("NuevoPedido") as string;
            if (objetoSerializado != null)
            {
                FacturaDeCompraFormViewModel facturaDeCompraFormViewModel = JsonConvert.DeserializeObject<FacturaDeCompraFormViewModel>(objetoSerializado);

                return facturaDeCompraFormViewModel; // Enviando el objeto como ViewModel a la vista
            }

            return null;
        }

        private void SetNuevoPedidoInSession(FacturaDeCompraFormViewModel facturaDeCompraFormViewModel)
        {
            string objetoSerializado = JsonConvert.SerializeObject(facturaDeCompraFormViewModel);
            HttpContext.Session.SetString("NuevoPedido", objetoSerializado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDetalle(FacturaDeCompraFormViewModel facturaDeCompraFormViewModel)
        {
            _newFacturaDeCompraFormViewModel = facturaDeCompraFormViewModel;
            FacturaDeCompraFormViewModel temp = GetNewPedidoFromSession();
            //obtengo datos de la nueva linea
            DetalleFacturaDto detalleFacturaDto = new DetalleFacturaDto();
            detalleFacturaDto.PublicacionId = facturaDeCompraFormViewModel.NewLine.PublicacionId;
            detalleFacturaDto.PublicacionDto = facturaDeCompraFormViewModel.NewLine.PublicacionDto;
            detalleFacturaDto.Cantidad =  facturaDeCompraFormViewModel.NewLine.Cantidad;
            _newFacturaDeCompraFormViewModel.NewLine = new DetalleFacturaDto();
            //agrego la nueva linea
            if (temp != null)
            {
                _newFacturaDeCompraFormViewModel.DetallesCompra = temp.DetallesCompra;
            }

            
            
            _newFacturaDeCompraFormViewModel.DetallesCompra.Add(detalleFacturaDto);
            SetNuevoPedidoInSession(_newFacturaDeCompraFormViewModel);
            
            
          
            //vuelvo al crear
            return RedirectToAction(nameof(Create));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FacturaDeCompraFormViewModel facturaDeCompraFormViewModel)
        {
            try
            {
                FacturaDeCompraDto facturaDeCompraDto = facturaDeCompraFormViewModel.ToFacturaDeCompraDto();
                facturaDeCompraDto.ProveedorDto = _servicioProveedor.Get(facturaDeCompraFormViewModel.ProveedorId);
                _servicioFacturaDeCompra.Add(facturaDeCompraDto);
                return RedirectToAction(nameof(Index));
                
            }
            catch(Exception e)
            {
                ViewBag.Message = e.ToString(); 
                return View(facturaDeCompraFormViewModel);
            }
        }

    }
}
