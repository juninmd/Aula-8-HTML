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

        [HttpGet]
        public ActionResult Fornecedor()
        {
            return View(new SOR_T_FORNECEDOR());
        }

        [HttpPost]
        public ActionResult Fornecedor(SOR_T_FORNECEDOR fornecedor)
        {
            var x = new FornecedorDao().Add(fornecedor, true);
            if (x.IsError)
            {
                ModelState.AddModelError("erro", x.Message);
                return View(fornecedor);
            }
            return View(new SOR_T_FORNECEDOR());

        }

    }
}