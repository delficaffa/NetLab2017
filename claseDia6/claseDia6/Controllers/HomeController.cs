using claseDia6.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace claseDia6.Controllers
{

    /*
       - Crear un sitio que cuente la cantidad de veces
         que se entro a la aplicacion en general.
         Mostrar en el footer
     
        crear una pantalla donde se pida un input con el nombre y
        un boton que vaya a otra pantalla
        y aparezca el msj Bienvenido X
   
        El nombre que se ingreso mostrarlo en el header a la derecha en todas las pantallas
        si el usuario no ingreso el nombre, no permitirle el ingreso a ninguna otra pantalla
        si trata de ir a otra pantalla rediridir a la pantlla de ingreso de nombre.
     
        Mostrar un contador en el footer de cantidad de visitantes(diferenciados por session)
        Agregar el menu logout para permitir volver a ingresar el nombre de usuario 
        el color del boton del login debe ser del color del menu

        Mostrar una pantalla con un listado de todas las personas que ingresaron al sitio
        (no repetidas) Agregar al menu.
        (Puede ser en memoria.)

        Ahora el sistema solo va a permitir el ingreso a la pantalla anterior si el usuario logueado es 'Admin'
     */

    public class HomeController : Controller
    {
        [Auth]
        public ActionResult Index()
        {
            return View();
        }
        //[Auth]
        //public ActionResult Contador()
        //{
        //    var count = 1;

        //    if (HttpContext.Application["count"] == null)
        //    {
        //        HttpContext.Application["count"] = count;
        //    }
        //    else
        //    {
        //        count = int.Parse(HttpContext.Application["count"].ToString()) + 1;
        //        HttpContext.Application["count"] = count;
        //    }

        //    ViewBag.Count = count;

        //    return View();
        //}

        [HttpPost]
        public ActionResult Visitas(string user)
        {
            HttpContext.Session["user"] = user;
            ViewBag.user = user;
            
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Saludo");
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
            return View("Saludo2");

        }


        [Auth]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Auth]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}