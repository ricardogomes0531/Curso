using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using I9Solucoes.Repositorios;
using I9Solucoes.Models;
using I9Solucoes.Filtro;

namespace I9Solucoes.Controllers
{
    public class CursoController : Controller
    {

[PermissoesFilters]
        public ActionResult Index(int idCurso)
        {
            List<Modulos> modulos = new List<Modulos>();
            modulos = new CursoRepository().ListarModulosDoCurso(idCurso);

            return View(modulos);
        }

        [HttpGet]
        public ActionResult Detalhe(int id)
        {
            Curso curso = new Curso();
            curso = new CursoRepository().Buscar(id);

            return View(curso);
        }

[PermissoesFilters]
        public ActionResult ListarAulas(int idCurso, int idModulo)
        {
            List<Aulas> aulas = new List<Aulas>();
            aulas = new CursoRepository().ListarAulasDoModulo(idCurso, idModulo);
            return View(aulas);
        }

[PermissoesFilters]
        public ActionResult AssistirAula(int idCurso, int idModulo, int idAula)
        {
            string conteudoAula = new CursoRepository().MostrarConteudoDaAula(idCurso, idModulo, idAula);
            ViewBag.conteudoAula = conteudoAula;
            return View();
        }

[PermissoesFilters]
        public ActionResult AssistirAulaMp3(int idCurso, int idModulo, int idAula)
        {
            string caminhoArquivo = new CursoRepository().PegarCaminhoDoArquivoMp3(idCurso, idModulo, idAula);
            ViewBag.caminhoArquivo = caminhoArquivo;
            return View();
        }
    }
}