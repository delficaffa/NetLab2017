using System;
using System.Web;
using System.Web.Mvc;

namespace Lunes4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Request;
            //Response;
            var example = Request.Cookies["example"].Value;

            var label = Session["session-Test"].ToString();
            var cookie = (HttpCookie)Session["COOKIE"];

            // application level 
            HttpContext.Application.Add("page-count",1);
            // request level
            HttpContext.Items.Add("page-count", 1);

            return View();
        }
        [HttpGet]
        public ActionResult LogOut()
        {
            Session.Clear();
            return View();
        }
        [HttpGet]
        public ActionResult RequestView()
        {
            var cookie = new HttpCookie("Hola", "Delfi")
            {
                Expires = DateTime.Now.AddYears(1)
            };

            Response.Cookies.Add(cookie);

            Session["session-Test"] = "Net Lab";
            Session["COOKIE"] = cookie;

            return View(this.Request);
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