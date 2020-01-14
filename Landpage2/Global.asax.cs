using Landpage2.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Landpage2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Lay1.Host_1 = Request.ServerVariables["SERVER_NAME"];  //"localhost";  
            string port_iis = ":" + Request.ServerVariables["SERVER_PORT"]; // :49857
            Lay1.Bag_dado42 = Request.Url.AbsolutePath;

            if (Lay1.Host_1 == "localhost")
            {
                Lay1.Desenv = "2";  // Desenvolvimento Debug
            }
            else
            {
                Lay1.Desenv = "1";  // Produção
            }

            Lay1.Host_2 = "http://" + Lay1.Host_1 + Lay1.Bag_dado42 + "/";

            if (Lay1.Desenv == "1")
            {
                if (port_iis == ":80")
                {
                    Lay1.Host_2 = "http://" + Lay1.Host_1 + Lay1.Bag_dado42 + "/";
                    Lay1.Host_3 = "http://" + Lay1.Host_1 + Lay1.Bag_dado42;
                }
                else
                {
                    Lay1.Host_2 = "http://" + Lay1.Host_1 + Lay1.Bag_dado42 + "/";
                    Lay1.Host_3 = "http://" + Lay1.Host_1 + Lay1.Bag_dado42;
                }
            }
            else
            {
                if (port_iis == ":80")
                {
                    Lay1.Host_2 = "http://" + Lay1.Host_1 + Lay1.Bag_dado42 + "/";
                    Lay1.Host_3 = "http://" + Lay1.Host_1 + Lay1.Bag_dado42;
                }
                else
                {
                    Lay1.Host_2 = "http://" + Lay1.Host_1 + port_iis + "/";
                    Lay1.Host_3 = "http://" + Lay1.Host_1 + port_iis;
                }

            }

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            HttpContext ctx = HttpContext.Current;
            Exception exception = ctx.Server.GetLastError();
            var httpException = exception as HttpException;
            var procp = exception.Message.ToString();

            if (procp.Contains("SQL Server"))
            {
                Lay1.Mensa_2 = procp;
                Response.Redirect("~/Error");
                //Server.Transfer("ErrorPage");
            }
            else
            {
                Lay1.Mensa_2 = procp;
                Response.Redirect("~/Error");
            }
            
        }

    }
}
