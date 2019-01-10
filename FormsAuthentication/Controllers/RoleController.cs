using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AAFormsAuthentication.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            //Vamos adicionar uma role sem a necessidade
            //De usar algum tipo de MemberShip
            //Vamos setar administrador como true e definir que este
            //usuario como administrados no Global.asax (VEJA como vica lá no Global.asax)
            var httpCookie = new HttpCookie("Administrador", "1");
            httpCookie.Expires = DateTime.Now + new TimeSpan(0, 10, 0, 0);

            HttpContext.Response.Cookies.Add(httpCookie);

            return RedirectToAction("Index", "Home");
        }
    }
}