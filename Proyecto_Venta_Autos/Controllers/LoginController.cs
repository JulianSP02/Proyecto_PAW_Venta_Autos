using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Venta_Autos.Models;
using Proyecto_Venta_Autos.Logica;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Proyecto_Venta_Autos.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(string NCorreo, string NContrasena)
        {
            Usuario oUsuario = UsuarioLogica.Instancia.Obtener(NCorreo, NContrasena);

            if (oUsuario == null)
            {
                ViewBag.Error = "Correo o contraseña no correcta";
                return View();
            }

            // Crear las claims del usuario
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, oUsuario.Correo),
                new Claim(ClaimTypes.Email, oUsuario.Correo),
                // Puedes agregar más claims según lo necesites
            };

            // Crear el identity del usuario
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // Crear los claims principal
            var principal = new ClaimsPrincipal(identity);

            // Iniciar sesión de forma asíncrona
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", oUsuario.EsAdministrador ? "Home" : "Tienda");
        }

        // GET: Login
        public ActionResult Registrarse()
        {
            return View(new Usuario());
        }

        [HttpPost]
        public ActionResult Registrarse(Usuario oUsuario)
        {
            if (oUsuario.Contrasena != oUsuario.ConfirmarContrasena)
            {
                ViewBag.Error = "Las contraseñas no coinciden";
                return View(oUsuario);
            }

            int idusuario_respuesta = UsuarioLogica.Instancia.Registrar(oUsuario);

            if (idusuario_respuesta == 0)
            {
                ViewBag.Error = "Error al registrar";
                return View();
            }

            return RedirectToAction("Index", "Login");
        }
    }
}
