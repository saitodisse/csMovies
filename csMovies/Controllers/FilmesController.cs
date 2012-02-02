using System.Collections.Generic;
using System.Web.Mvc;
using Dominio.Entidades;
using InfraNhibernate.Repositorios;

namespace csMovies.Controllers
{
    public class FilmesController : Controller
    {
        private FilmeDAO _filmeDAO;

        public FilmesController(FilmeDAO filmeDAO)
        {
            _filmeDAO = filmeDAO;
        }

        //
        // GET: /Filmes/

        public ActionResult Index()
        {
            return View(_filmeDAO.GetAll());
        }

        //
        // GET: /Filmes/Details/5

        public ActionResult Details(int id)
        {
            return View(_filmeDAO.Get(id));
        }

        //
        // GET: /Filmes/Create

        public ActionResult Create()
        {
            return View(new Filme());
        } 

        //
        // POST: /Filmes/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Filmes/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View(_filmeDAO.Get(id));
        }

        //
        // POST: /Filmes/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Filmes/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(_filmeDAO.Get(id));
        }

        //
        // POST: /Filmes/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
