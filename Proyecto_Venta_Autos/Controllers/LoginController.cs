using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Venta_Autos.Models;
using Proyecto_Venta_Autos.Logica;
using System.Collections.Generic;
using System.Security.Claims;

namespace ProyectoTest.Controllers
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
            Usuario oUsuario = new Usuario();
            oUsuario = UsuarioLogica.Instancia.Obtener(NCorreo, NContrasena);

            if (oUsuario == null)
            {
                ViewBag.Error = "Correo o contraseña no correcta";
                return View();
            }

            // Crear las claims del usuario
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, oUsuario.Correo),
                new Claim(ClaimTypes.Role, oUsuario.EsAdministrador ? "Administrador" : "Usuario")
            };

            // Crear la identidad y el principal
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            // Autenticar al usuario
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

            // Redirigir según el rol del usuario
            if (oUsuario.EsAdministrador)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Tienda");
            }
        }

        // GET: Login
        public ActionResult Registrarse()
        {
            return View(new Usuario() { Nombres = "", Apellidos = "", Correo = "", Contrasena = "", ConfirmarContrasena = "" });
        }

        [HttpPost]
        public ActionResult Registrarse(string NNombres, string NApellidos, string NCorreo, string NContrasena, string NConfirmarContrasena)
        {
            Usuario oUsuario = new Usuario()
            {
                Nombres = NNombres,
                Apellidos = NApellidos,
                Correo = NCorreo,
                Contrasena = NContrasena,
                ConfirmarContrasena = NConfirmarContrasena,
                EsAdministrador = false
            };

            if (NContrasena != NConfirmarContrasena)
            {
                ViewBag.Error = "Las contraseñas no coinciden";
                return View(oUsuario);
            }
            else
            {
                int idusuario_respuesta = UsuarioLogica.Instancia.Registrar(oUsuario);
                if (idusuario_respuesta == 0)
                {
                    ViewBag.Error = "Error al registrar";
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
        }
    }
}