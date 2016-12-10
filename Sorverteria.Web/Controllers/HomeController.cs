using System.Collections.Generic;
using System.Web.Mvc;
using Sorveteria.Dao;
using Sorveteria.Model;

namespace Sorverteria.Web.Controllers
{
    public class HomeController : Controller
    {
        public SorveteDao SorveteDao => new SorveteDao();

        public ActionResult Index()
        {
            var listaSorvetes = SorveteDao.GetAll().Content;

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