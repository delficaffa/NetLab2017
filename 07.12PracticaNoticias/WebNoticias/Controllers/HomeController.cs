using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebNoticias.Filters;

namespace WebNoticias.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        { 
            return View();
        }

        [AuthorizationFilterAtribute]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AuthorizationFilterAtribute]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
           return View();
        }

        [AuthorizationFilterAtribute]
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            ControllerContext.HttpContext.Session["LoggedUser"] = username;
            return View();
        }
        [AuthorizationFilterAtribute]
        [HttpPost]
        public ActionResult LogOut()
        {
            ControllerContext.HttpContext.Session.Remove("LoggedUser");
            return View();
        }
    }
}