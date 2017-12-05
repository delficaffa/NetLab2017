using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCFilters.Filters
{
    public class AuthFilterAtributte : AuthorizeAttribute
    {
        public bool isLogged = false;

        protected override bool AuthorizeCore(HttpContext httpContext)
        {
            if (!isLogged)
            {
                throw new HttpException(HttpStatusCode.Unauthorized.ToString());
            }
            return base.AuthorizeCore(httpContext); //EL ERRROR ES LO QUE ESTA ENTRE ()
        }
    }
}