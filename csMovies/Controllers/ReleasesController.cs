using System.Web.Mvc;
using Dominio.Entidades;
using Dominio.Servicos;

namespace csMovies.Controllers
{
    public class ReleasesController : Controller
    {
        private readonly ReleaseServico _releaseServico;

        public ReleasesController(ReleaseServico releaseServico)
        {
            _releaseServico = releaseServico;
        }

        //
        // GET: /Releases/

        public ActionResult Index()
        {
            return View(_releaseServico.PesquisarTodos());
        }

        //
        // GET: /Releases/Details/5

        public ActionResult Details(int id)
        {
            return View(_releaseServico.Pesquisar(id));
        }
    }
}
