using Disquera.AccesoDatos.Data.Repository.Irepository;
using Disquera.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Disquera.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContenedorTrabajo contenedor;

        public HomeController(ILogger<HomeController> logger, IContenedorTrabajo _contenedor)
        {
            _logger = logger;
            contenedor = _contenedor;
        }

        public IActionResult Index()
        {
            VistasVM clientesVM = new VistasVM()
            {
                Listabum = contenedor.GetAlbum.GetAll(),
                Listatista = contenedor.GetArtista.GetAll()


            };


            return View(clientesVM);
        }

        public IActionResult vista()
        {
            VistasVM clientesVM = new VistasVM()
            {
                Listabum = contenedor.GetAlbum.GetAll(),
                Listatista = contenedor.GetArtista.GetAll()


            };


            return View(clientesVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
