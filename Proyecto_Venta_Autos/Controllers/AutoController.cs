using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Venta_Autos.Models;

namespace Proyecto_Venta_Autos.Controllers
{
    public class AutoController : Controller
    {
        private readonly VentaAutosDbContext _context;

        public AutoController(VentaAutosDbContext context)
        {
            _context = context;
        }

        // GET: Auto
        public async Task<IActionResult> Index()
        {
            var Autos = await _context.Autos.ToListAsync();
            return View(Autos);
        }

        // GET: Auto/Detail/1
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || _context.Autos == null)
            {
                return NotFound();
            }

            var auto = await _context.Autos.FirstOrDefaultAsync(m => m.Id == id);
            if(auto == null)
            {
                return NotFound();
            }

            return View(auto);
        }


    }
}
