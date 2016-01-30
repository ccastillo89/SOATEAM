using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UPC.SisTictecks.Web.Controllers
{
    public class GestionCitasController : Controller
    {
        private GestionCitasWS.GestionCitasServiceClient GestionCitasProxy = new GestionCitasWS.GestionCitasServiceClient();

        //
        // GET: /GestionCitas/
        public ActionResult Index()
        {
            return View(GestionCitasProxy.ListarCitas().ToList());
        }

        //
        // GET: /GestionCitas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /GestionCitas/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /GestionCitas/Create
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
        // GET: /GestionCitas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /GestionCitas/Edit/5
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
        // GET: /GestionCitas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /GestionCitas/Delete/5
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
