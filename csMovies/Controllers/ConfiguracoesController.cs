using System;
using System.Web.Mvc;
using Dominio.Entidades;
using Dominio.Servicos;

namespace csMovies.Controllers
{
    public class ConfiguracoesController : Controller
    {
        private readonly AdministradorServico _administradorServico;
        private readonly ConfiguracoesGeraisServico _configuracoesGeraisServico;

        public ConfiguracoesController(AdministradorServico administradorServico, ConfiguracoesGeraisServico configuracoesGeraisServico)
        {
            _administradorServico = administradorServico;
            _configuracoesGeraisServico = configuracoesGeraisServico;
        }

        //
        // GET: /Configuracoes/
        public ActionResult Index()
        {
            var configuracoesGerais = _configuracoesGeraisServico.Pesquisar();
            return View(configuracoesGerais);
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
            return Redirect("Index");
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



        //
        // GET: /Filmes/Edit/5

        public ActionResult Edit()
        {
            return View(_configuracoesGeraisServico.Pesquisar());
        }

        //
        // POST: /Filmes/Edit/5

        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                var configuracoesGerais = _configuracoesGeraisServico.Pesquisar();
                configuracoesGerais.TamanhoMinimoArquivos = Convert.ToInt64(collection["TamanhoMinimoArquivos"]);
                configuracoesGerais.TiposArquivosPadrao = collection["TiposArquivosPadrao"];
                _configuracoesGeraisServico.Salvar(configuracoesGerais);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
