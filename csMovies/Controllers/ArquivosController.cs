using System.Web.Mvc;
using Dominio.Servicos;

namespace csMovies.Controllers
{
    public class ArquivosController : Controller
    {
        private readonly ArquivoServico _arquivoServico;

        public ArquivosController(ArquivoServico arquivoServico)
        {
            _arquivoServico = arquivoServico;
        }

        //
        // GET: /Arquivos/

        public ActionResult Index()
        {
            return View(_arquivoServico.PesquisarTodos());
        }

        //
        // GET: /Arquivos/Details/5

        public ActionResult Details(int id)
        {
            return View(_arquivoServico.Pesquisar(id));
        }
    }
}
