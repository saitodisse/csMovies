using System.Web.Mvc;
using Dominio.Entidades;
using Dominio.Servicos;

namespace OurMoviesMvc.Controllers
{
    public class ConfiguracoesController : Controller
    {
        private readonly IAdministradorServico _administradorServico;

        public ConfiguracoesController(IAdministradorServico administradorServico)
        {
            _administradorServico = administradorServico;
        }

        //
        // GET: /Configuracoes/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Configuracoes/AutoCriarBancoDados
        public ActionResult AutoCriarBancoDados()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AutoCriarBancoDados(FormCollection formCollection)
        {
            _administradorServico.AutoCriarBancoDeDados();
            ViewBag.Mensagem = "Banco de Dados (re)criado com sucesso!!";
            return View("Index");
        }

        public ActionResult CriarDadosTeste()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CriarDadosTeste(FormCollection formCollection)
        {
            Filme filme = _administradorServico.InserirDadosTeste();
            return Redirect("ExibirDadosTeste/" + filme.Id);
        }

        public ActionResult ExibirDadosTeste(int id)
        {
            ViewBag.Mensagem = "Dados criados com sucesso";
            Filme filme = _administradorServico.PesquisarFilme(id);
            ViewBag.Arquivos = _administradorServico.PesquisarArquivosPorFilme(id);

            return View(filme);
        }
    }
}
