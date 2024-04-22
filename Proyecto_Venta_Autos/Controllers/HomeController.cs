using Microsoft.AspNetCore.Mvc;
using Proyecto_Venta_Autos.Models;
using System.Diagnostics;

namespace Proyecto_Venta_Autos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Tienda()
        {
            return View();
        }
        public IActionResult Producto()
        {
            return View();
        }
        public IActionResult Marca()
        {
            return View();
        }
        public IActionResult Categoria()
        {
            return View();
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
