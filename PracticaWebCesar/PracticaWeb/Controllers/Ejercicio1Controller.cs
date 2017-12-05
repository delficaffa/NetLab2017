using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaWeb.Controllers
{
    public class Ejercicio1Controller : Controller
    {
        // GET: Ejercicio1
        public ActionResult Sumar()
        { 
            return View();
        }

        [HttpPost]
        public ActionResult Sumar(int a,int b, int c)
        {
            var resultado = a + b + c;

            ViewData.Add("resultado", resultado);

            return View();
            
        }
        

    }
}
