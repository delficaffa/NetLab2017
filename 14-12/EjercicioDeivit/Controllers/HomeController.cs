using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjercicioDeivit.Controllers
{
    /*
    1- Crear una clase persna con Nombre requerido mx 50
    Apellido requerido max 50,
    edad(No puede ser menor a 13)
    2- Crear un formulario de MVC Para crear una persona usar HTML (no razor)
    3- Validad que el nombre y el apellido sean distintos
     */
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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