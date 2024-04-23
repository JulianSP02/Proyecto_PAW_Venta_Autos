using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto_Venta_Autos.Logica;
using Proyecto_Venta_Autos.Models;

namespace Proyecto_Venta_Autos.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categoria()
        {
            return View();
        }

        public ActionResult Marca()
        {
            return View();
        }

        public ActionResult Producto()
        {
            return View();
        }

        public ActionResult Tienda()
        {
            return View();
        }

        public JsonResult ListarCategoria()
        {
            List<Categoria> oLista = CategoriaLogica.Instancia.Listar();
            return Json(new { data = oLista });
        }

        [HttpPost]
        public JsonResult GuardarCategoria(Categoria objeto)
        {
            bool respuesta = (objeto.IdCategoria == 0) ? CategoriaLogica.Instancia.Registrar(objeto) : CategoriaLogica.Instancia.Modificar(objeto);
            return Json(new { resultado = respuesta });
        }

        [HttpPost]
        public JsonResult EliminarCategoria(int id)
        {
            bool respuesta = CategoriaLogica.Instancia.Eliminar(id);
            return Json(new { resultado = respuesta });
        }

        public JsonResult ListarMarca()
        {
            List<Marca> oLista = MarcaLogica.Instancia.Listar();
            return Json(new { data = oLista });
        }

        [HttpPost]
        public JsonResult GuardarMarca(Marca objeto)
        {
            bool respuesta = (objeto.IdMarca == 0) ? MarcaLogica.Instancia.Registrar(objeto) : MarcaLogica.Instancia.Modificar(objeto);
            return Json(new { resultado = respuesta });
        }

        [HttpPost]
        public JsonResult EliminarMarca(int id)
        {
            bool respuesta = MarcaLogica.Instancia.Eliminar(id);
            return Json(new { resultado = respuesta });
        }

        public JsonResult ListarProducto()
        {
            List<Producto> oLista = ProductoLogica.Instancia.Listar();
            return Json(new { data = oLista });
        }

        [HttpPost]
        public JsonResult GuardarProducto(string objeto)
        {
            Response oresponse = new Response() { resultado = true, mensaje = "" };

            try
            {
                Producto oProducto = JsonConvert.DeserializeObject<Producto>(objeto);

                if (oProducto.IdProducto == 0)
                {
                    int id = ProductoLogica.Instancia.Registrar(oProducto);
                    oProducto.IdProducto = id;
                    oresponse.resultado = oProducto.IdProducto == 0 ? false : true;
                }
                else
                {
                    oresponse.resultado = ProductoLogica.Instancia.Modificar(oProducto);
                }
            }
            catch (Exception e)
            {
                oresponse.resultado = false;
                oresponse.mensaje = e.Message;
            }

            return Json(oresponse);
        }

        [HttpPost]
        public JsonResult EliminarProducto(int id)
        {
            bool respuesta = ProductoLogica.Instancia.Eliminar(id);
            return Json(new { resultado = respuesta });
        }
    }

    public class Response
    {
        public bool resultado { get; set; }
        public string mensaje { get; set; }
    }
}
