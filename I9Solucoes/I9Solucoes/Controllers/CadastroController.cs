using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using I9Solucoes.Repositorios;
using I9Solucoes.Models;

namespace I9Solucoes.Controllers
{
    public class CadastroController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult Salvar()
        {
            CadastroRepository cadastro = new CadastroRepository();
            bool resultado = false;
            try
            {
                                resultado = cadastro.Inserir(Request.QueryString["nome"].ToString(), Convert.ToDateTime(Request.QueryString["dataNascimento"].ToString()), Request.QueryString["cpf"].ToString(), Request.QueryString["sexo"].ToString(), Request.QueryString["email"].ToString(), Request.QueryString["celular"].ToString(), Request.QueryString["whatsapp"].ToString(), Request.QueryString["senha"].ToString());
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}