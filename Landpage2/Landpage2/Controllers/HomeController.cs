using Landpage2.DataAccess;
using System;
using System.Web.Mvc;

namespace Landpage2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //using (var contexto = new Contexto())
            //{
            //    string dat_zo1 = DateTime.Now.ToString("d");
            //    string strQueryUpdat1 = "INSERT INTO banco_01 (desc_zone,desc_zona,id_date,isys,id_dias) VALUES ('', '', '', '')";
            //    contexto.ExecutaComando(strQueryUpdat1);
            //    contexto.Close();
            //}


            return View();
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