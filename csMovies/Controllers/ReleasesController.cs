using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.Entidades;
using InfraNhibernate.Repositorios;

namespace csMovies.Controllers
{
    public class ReleasesController : Controller
    {
        private ReleaseDAO _releaseDAO;

        public ReleasesController(ReleaseDAO releaseDAO)
        {
            _releaseDAO = releaseDAO;
        }

        //
        // GET: /Releases/

        public ActionResult Index()
        {
            return View(_releaseDAO.GetAll());
        }

        //
        // GET: /Releases/Details/5

        public ActionResult Details(int id)
        {
            return View(_releaseDAO.Get(id));
        }

        //
        // GET: /Releases/Create

        public ActionResult Create()
        {
            return View(new Release());
        } 

        //
        // POST: /Releases/Create

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
        // GET: /Releases/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View(_releaseDAO.Get(id));
        }

        //
        // POST: /Releases/Edit/5

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
        // GET: /Releases/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(_releaseDAO.Get(id));
        }

        //
        // POST: /Releases/Delete/5

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
