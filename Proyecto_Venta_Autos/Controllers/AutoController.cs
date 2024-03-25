using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Venta_Autos.Controllers
{
    public class AutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
