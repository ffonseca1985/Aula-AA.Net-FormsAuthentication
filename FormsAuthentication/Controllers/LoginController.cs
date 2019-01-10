using AAFormsAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Para se autenticar via FormsAuthentication
//Temos que usar o seguinte Namespace:
using System.Web.Security;

namespace AAFormsAuthentication.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken] //Validando a origem.
        [HttpPost]
        public ActionResult Index(LoginModel login, string returnUrl)
        {
            //Para logar basta usarmos a seguinte Classe (FormsAuthentication.SetAuthCookie)
            //É criado um cookie e este cookie é persistido na máquina do usuário
            //Cada vez que o usuario envia uma requisição para o usuario este cookie
                //é enviado junto
            if (login.User == "ffonseca" && login.Password == "123456")
            {
                FormsAuthentication.SetAuthCookie("ffonseca", true);
                if (string.IsNullOrEmpty(returnUrl))
                    return RedirectToAction("Index", "Home");
                else
                    if (returnUrl == "/")
                        return RedirectToAction("Index", "Home");
                    else
                        return RedirectToAction("Index", returnUrl.Replace("/", ""));
            }
            else
                ViewBag.loginResult = "Usuário e senha inválidos";
            
            return View();
        }

        public ActionResult LogOff() {

            //Para fazer o loggOff basta usar o comando abaixo
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}