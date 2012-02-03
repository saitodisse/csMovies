using System.Web.Mvc;
using Dominio.Entidades;
using Dominio.Servicos;

namespace csMovies.Controllers
{
    public class FilmesController : Controller
    {
        private readonly FilmeServico _filmeServico;

        public FilmesController(FilmeServico filmeServico)
        {
            _filmeServico = filmeServico;
        }

        //
        // GET: /Filmes/

        public ActionResult Index()
        {
            return View(_filmeServico.PesquisarTodos());
        }

        //
        // GET: /Filmes/Details/5

        public ActionResult Details(int id)
        {
            return View(_filmeServico.Pesquisar(id));
        }
    }
}
