using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.Entidades;
using InfraNhibernate.Repositorios;

namespace csMovies.Controllers
{
    public class ArquivosController : Controller
    {
        private ArquivoDAO _arquivoDAO;

        public ArquivosController(ArquivoDAO arquivoDAO)
        {
            _arquivoDAO = arquivoDAO;
        }

        //
        // GET: /Arquivos/

        public ActionResult Index()
        {
            return View(_arquivoDAO.GetAll());
        }

        //
        // GET: /Arquivos/Details/5

        public ActionResult Details(int id)
        {
            return View(_arquivoDAO.Get(id));
        }

        //
        // GET: /Arquivos/Create

        public ActionResult Create()
        {
            return View(new Arquivo());
        } 

        //
        // POST: /Arquivos/Create

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
        // GET: /Arquivos/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View(_arquivoDAO.Get(id));
        }

        //
        // POST: /Arquivos/Edit/5

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
        // GET: /Arquivos/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(_arquivoDAO.Get(id));
        }

        //
        // POST: /Arquivos/Delete/5

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
