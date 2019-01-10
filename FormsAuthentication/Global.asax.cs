using AAFormsAuthentication.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace AAFormsAuthentication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Habilitando o Filtro para aceitar apenas requisições
            //Autenticadas
            //Analisar webconfig para verificar a configuração de
            //Autenticação
            FilterConfig.RouteConfig(GlobalFilters.Filters);
        }
        //Evento que permite criar uma role do usuário
        //Como funcionava antes do OWIN
        public void Application_OnPostAuthorizeRequest()
        {
            //Simulando se o usuário é administrador
            if (Context.Request.Cookies["Administrador"] == null)
                return;

            if (Context.Request.Cookies["Administrador"].ToString() == "1")
                return;
            //Pegando o nome do cookie criado na autenticação
            //Ver web.config
            var cookiename = FormsAuthentication.FormsCookieName;

            //Verirficando se não é nulo
            if (cookiename == null)
                return;

            //Pegando o valor do cookie
            HttpCookie cookie = Context.Request.Cookies[cookiename];

            //Verificando se não é nulo
            if (cookie == null)
                return;

            //Decriptografando o tiket criado quando é feito o login
            var tiket = FormsAuthentication.Decrypt(cookie.Value);

            if (tiket != null)
            {
                //Criando uma identidade com o ticket de autenticão
                var identity = new FormsIdentity(tiket);
                
                //Criando um ambiente de autenticação com a role criada
                var principal = new GenericPrincipal(identity, new[] { "Administrador" });

                //Registrando o nossas credenciais no principal do context do usuário
                HttpContext.Current.User = principal;
            }
        }
    }
}
