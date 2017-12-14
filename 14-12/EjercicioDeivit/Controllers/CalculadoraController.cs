using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjercicioDeivit.Controllers
{
    public class CalculadoraController : Controller
    {
        public ActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(Calculadora calculadora)
        {

            return View();

        }
    }
}
