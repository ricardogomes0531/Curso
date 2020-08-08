using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using I9Solucoes.Repositorios;

namespace I9Solucoes.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Logar(string email, string senha)
		{
			var resultado = new UsuarioRepository().Autenticar(email, senha);
			return Json(resultado,JsonRequestBehavior.AllowGet);
		}
	}
}