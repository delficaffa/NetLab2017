using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspnet.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            //var x = Request.RequestType;
            var cookie = new HttpCookie("example", "ARG")
            {
                Expires = DateTime.Now.AddYears(1)
            };
            Response.Cookies.Add(cookie);

            Session["session-test"] = "Net Lab";
            //Session.clear();
            //var label = Session["session-test"].ToString();

            //HttpContext.Application.Add("page-counter",1)

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