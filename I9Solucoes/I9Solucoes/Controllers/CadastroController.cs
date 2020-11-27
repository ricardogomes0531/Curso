﻿using System;
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

        [HttpPost]
        public JsonResult Salvar()
        {
            CadastroRepository cadastro = new CadastroRepository();
            bool resultado = false;
            Erro erro = new Erro();
            try
            {
                resultado = cadastro.Inserir(Request.Form["nome"].ToString(), Convert.ToDateTime(Request.Form["dataNascimento"].ToString()), Request.Form["cpf"].ToString(), Request.Form["sexo"].ToString(), Request.Form["email"].ToString(), Request.Form["celular"].ToString(), Request.Form["whatsapp"].ToString(), Request.Form["senha"].ToString());
                if (resultado)
                {
                    erro.Mensagem = "Cadastro realizado com sucesso";
                    erro.Detalhe = null;
                    erro.ExisteErro =false;
                }
                else
                {
                    erro.Mensagem = "Erro ao realizar o cadastro.";
                    erro.Detalhe = null;
                    erro.ExisteErro = true;
                }
            }
            catch (Exception ex)
            {
                erro.Mensagem = "Erro ao realizar cadastro " + ex.Message;
                erro.Detalhe = ex.Message;
                erro.ExisteErro = true;
            }
                        return Json(erro, JsonRequestBehavior.AllowGet);
        }
    }
}