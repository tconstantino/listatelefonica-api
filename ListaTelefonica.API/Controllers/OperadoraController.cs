using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListaTelefonica.Domain.Repository;

namespace ListaTelefonica.API.Controllers
{
    public class OperadoraController : Controller
    {
        public OperadoraController(IOperadoraRepository operadoraRepository)
        {
            OperadoraRepository = operadoraRepository;
        }

        private IOperadoraRepository OperadoraRepository { get; set; }

        // GET: Operadora
        public ActionResult Index()
        {
            return View();
        }

        // GET: Operadora/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Operadora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Operadora/Create
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

        // GET: Operadora/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Operadora/Edit/5
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

        // GET: Operadora/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Operadora/Delete/5
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
