using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebNoticias.Filters
{
    public class AuthorizationFilterAtribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var loggedUser = filterContext.HttpContext.Session["LoggedUser"];

            if (loggedUser == null)
            {
                filterContext.Result = new RedirectResult("/Home/Login");
                return;
            }

            base.OnActionExecuting(filterContext);

        }
    }
}