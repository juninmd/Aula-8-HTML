using System.Web.Mvc;
using Sorveteria.Dao;
using Sorveteria.Model;

namespace Sorverteria.Web.Controllers
{
    public class LoginController : Controller
    {
        public UsuarioDao UsuarioDao => new UsuarioDao();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SOR_T_USUARIO user)
        {

            if (UsuarioDao.GetById(user.EMAIL, user.SENHA).IsError)
            {
                ModelState.AddModelError("senha", "senha invalida");
                return View();
            }
            return RedirectToAction("Index", "Home");

        }
    }
}