using Landpage2.Models;
using System.Web.Mvc;

namespace Landpage2.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            ViewData["mensagem"] = Lay1.Mensa_2;
            return View();
        }
    }
}