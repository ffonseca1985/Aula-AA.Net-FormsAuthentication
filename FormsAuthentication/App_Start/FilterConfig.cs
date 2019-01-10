using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AAFormsAuthentication.App_Start
{
    public static class FilterConfig
    {
        //Para que seja possivel habilitar apenas o login basta registrar
        //o seguinte filtro
        public static void RouteConfig(GlobalFilterCollection filters)
        {
            filters.Add(new AuthorizeAttribute());
        }
    }
}