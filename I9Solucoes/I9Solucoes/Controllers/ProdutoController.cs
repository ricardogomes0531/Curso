using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using I9Solucoes.Models;
using I9Solucoes.Repositorios;

namespace I9Solucoes.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastra()
        {
            return View();
                }

        public ActionResult Cadastrar()
        {
                        var resultado = new ProdutoRepository().Inserir(Convert.ToInt32(Request.QueryString["idFornecedor"]), Request.QueryString["usuarioCadastro"], Convert.ToDecimal(Request.QueryString["custo"]), Convert.ToDecimal(Request.QueryString["custoVenda"]), Request.QueryString["localizacao"], Request.QueryString["marca"], Convert.ToDateTime(Request.QueryString["dataValidade"]), Convert.ToInt32(Request.QueryString["estoqueMinimo"]), Convert.ToInt32(Request.QueryString["prazoEntregaFornecedor"]));
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}