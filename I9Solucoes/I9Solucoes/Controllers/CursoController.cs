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
            HttpCookie cookieLogin = Request.Cookies["login"];
            var idAluno = new UsuarioRepository().PesquisarIdDoAlunoPeloEmail(cookieLogin.Value.ToString());
            aulas = new CursoRepository().ListarAulasDoModulo(idCurso, idModulo, idAluno);
            return View(aulas);
        }

[PermissoesFilters]
        public ActionResult AssistirAula(int idCurso, int idModulo, int idAula)
        {
            string conteudoAula = new CursoRepository().MostrarConteudoDaAula(idCurso, idModulo, idAula);
            ViewBag.conteudoAula = conteudoAula;
            HttpCookie cookieLogin = Request.Cookies["login"];
            var idAluno = new UsuarioRepository().PesquisarIdDoAlunoPeloEmail(cookieLogin.Value.ToString());
new CursoRepository().RemoverFrequencia(idCurso, idModulo, idAula, idAluno);
                new CursoRepository().InserirFrequencia(idCurso, idModulo, idAula, idAluno);
            return View();
        }

[PermissoesFilters]
        public ActionResult AssistirAulaMp3(int idCurso, int idModulo, int idAula)
        {
            string caminhoArquivo = new CursoRepository().PegarCaminhoDoArquivoMp3(idCurso, idModulo, idAula);
            ViewBag.caminhoArquivo = caminhoArquivo;
            HttpCookie cookieLogin = Request.Cookies["login"];
            var idAluno = new UsuarioRepository().PesquisarIdDoAlunoPeloEmail(cookieLogin.Value.ToString());
 new CursoRepository().RemoverFrequencia(idCurso, idModulo, idAula, idAluno);
                new CursoRepository().InserirFrequencia(idCurso, idModulo, idAula, idAluno);
            return View();
        }

[PermissoesFilters]
        public ActionResult Inscrever(int idCurso)
        {
            Curso curso = new CursoRepository().Buscar(idCurso);
            ViewBag.idCurso = curso.Id;
            ViewBag.tempoDuracao = curso.TempoPrevistoDuracao;
            ViewBag.dataInicial = curso.DataInicio;
            ViewBag.valorMonetario = curso.ValorMonetario;
            List<TempoCobrancaCurso> tempoCobranca = new CursoRepository().BuscarTempoCobranca(idCurso);
            ViewBag.tempoCobranca = tempoCobranca.ToList();
            return View();
                    }

        [HttpPost]
        public JsonResult InscreverNoCurso()
        {
                        var idCurso = Convert.ToInt32(Request.Form["idCurso"]);
            HttpCookie cookieLogin = Request.Cookies["login"];
            var idAluno = new UsuarioRepository().PesquisarIdDoAlunoPeloEmail(cookieLogin.Value.ToString());
            var idTempoAssinatura=Convert.ToInt32(Request.Form["tempoAssinatura"]);
            int tempo= new CursoRepository().BuscarTempoDoCurso(idTempoAssinatura, idCurso);
            DateTime dataInicio = new CursoRepository().Buscar(idCurso).DataInicio;
            var dataFim=dataInicio.AddMonths(tempo);
            Erro erro = new Erro();
            try
            {
                bool existeAluno = new CursoRepository().ChecarSeAlunoJaEstarInscritoNoCurso(idAluno, idCurso);
                if (existeAluno)
                {
                    erro.ExisteErro = true;
                    erro.Detalhe = null;
                    erro.Mensagem = "Você já está inscrito neste curso.";
                }
                else
                {
                    bool alunoInserido = new CursoRepository().InserirAlunoNoCurso(idCurso, idAluno, dataFim,dataInicio);
                    if (alunoInserido)
                    {
                        erro.Mensagem = "Inscrição realizada com sucesso!";
                        erro.Detalhe = null;
                        erro.ExisteErro = false;
                    }
                    else
                    {
                        erro.ExisteErro = true;
                        erro.Detalhe = null;
                        erro.Mensagem = "Erro ao realizar inscrição no curso.";
                    }
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

[PermissoesFilters]
        public ActionResult TodosOsCursos()
        {
            return View();
        }
        
        public ActionResult LiberarCurso(int idCurso, int idAluno)
        {
                                    bool liberado = new CursoRepository().LiberarCursoParaAluno(idCurso, idAluno);
            ViewBag.liberado = liberado;
            return View();

        }
    }
}