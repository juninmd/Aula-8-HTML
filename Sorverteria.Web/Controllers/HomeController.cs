using System.Collections.Generic;
using System.Web.Mvc;
using Sorveteria.Model;

namespace Sorverteria.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var listaSorvetes = new List<SOR_T_SORVETE>();
         

            return View(listaSorvetes);
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