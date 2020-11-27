using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using I9Solucoes.Repositorios;
using I9Solucoes.Models;

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

		[HttpGet]
		public ActionResult Cursos()
		{
			 List<Curso> cursos = new List<Curso>();
			try
			{
				cursos = new CursoRepository().Listar();
							}
			catch (Exception ex)
			{
				return Json(ex.Message, JsonRequestBehavior.AllowGet);
			}
			return Json(cursos,JsonRequestBehavior.AllowGet);
		}

	}
}