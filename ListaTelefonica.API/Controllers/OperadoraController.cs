using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Domain.Repository;
using ListaTelefonica.Infrastructure;
using ListaTelefonica.Infrastructure.Repository;

namespace ListaTelefonica.API.Controllers
{
    public class OperadoraController : Controller
    {        
        private IOperadoraRepository OperadoraRepository { get; set; }

        // GET: /Operadora/{id}
        public ActionResult Index()
        {
            var teste = new Class1();
            teste.TESTE();
                return Content("OK");
            
        }

       

        // GET: Operadora/Create
        //[HttpPut]
        //public ActionResult Index(Operadora operadora)
        //{
        //    return View();
        //}

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
