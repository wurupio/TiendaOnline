using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppVentas.Controllers
{
    public class ColeccionesController : Controller
    {
        // GET: Colecciones
        public ActionResult Summer()
        {
            return View();
        }
        public ActionResult Scape()
        {
            return View();
        }
        public ActionResult Line()
        {
            return View();
        }

        // GET: Colecciones/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Colecciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Colecciones/Create
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

        // GET: Colecciones/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Colecciones/Edit/5
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

        // GET: Colecciones/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Colecciones/Delete/5
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
