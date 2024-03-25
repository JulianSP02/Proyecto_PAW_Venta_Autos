using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Venta_Autos.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
