using System.Collections.Generic;
using System.Web.Mvc;
using Sorverteria.Web.Models;

namespace Sorverteria.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var listaSorvetes = new List<Sorvete>()
            {
                new Sorvete
                {
                    Sabor = "Morango",
                    Descricao = "Muito bom!!!",
                    Foto = "http://www.receitasdemae.com.br/wp-content/uploads/2013/01/sorvete-de-morango.jpg"
                },
                 new Sorvete
                {
                    Sabor = "Chocolate",
                    Descricao = "Muito bom!!!",
                    Foto = "http://s.glbimg.com/po/rc/media/2013/01/03/09_27_31_109_sorvete.jpg"
                },
                  new Sorvete
                {
                    Sabor = "Abacaxi",
                    Descricao = "Muito abacaxi!!!",
                    Foto = "http://www.receitasanamaria.net/wp-content/uploads/2015/01/Receita-Sorvete-Cremoso-de-Abacaxi.jpg"
                }
            };

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