using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindApp.Controllers
{
    public class RegionController : Controller
    {
        public ActionResult Index()
        {
            List<Region> regions;

            using (var context = new BaseDatos() )
            {
                regions = context.Region.ToList();
            }
            return View(regions);
        }
    }
}
