﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjercicioDeivit.Controllers
{
    public class CrearPersonaController : Controller
    {
     
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Persona persona)
        {

            return View();
           
        }

    }
}
