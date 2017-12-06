using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace claseDia6.Controllers
{

    /*
     *  - Crear un sitio que cuente la cantidad de veces
     *    que se entro a la aplicacion en general.
          Mostrar en el footer
     */

        /*crear una pantalla donde se pida un input con el nombre y
         un boton que vaya a otra pantalla
          y aparezca el msj Bienvenido X
         */

        /*
            El nombre que se ingreso mostrarlo en el header a la derecha en todas las pantallas
            si el usuario no ingreso el nombre, no permitirle el ingreso a ninguna otra pantalla
            si trata de ir a otra pantalla rediridir a la pantlla de ingreso de nombre.
         */

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult Contador()
        {
            var count = 1;

            if (HttpContext.Application["count"] == null)
            {
                HttpContext.Application["count"] = count;
            }
            else
            {
                count = int.Parse(HttpContext.Application["count"].ToString()) + 1;
                HttpContext.Application["count"] = count;
            }

            ViewBag.Count = count;

            return View();
        }

        public ActionResult Saludo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Saludo(string nombre)
        {
            HttpContext.Session["user"] = nombre;
            ViewBag.nombre = nombre;
            return View("Saludo2");
             
        }
             
	}
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}