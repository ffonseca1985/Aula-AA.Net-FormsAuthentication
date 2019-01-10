using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AAFormsAuthentication.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class AdministradorController : Controller
    {
        // GET: Administrador

        public ActionResult Index()
        {
            return View();
        }
    }
}