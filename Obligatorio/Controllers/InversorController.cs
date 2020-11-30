using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Repositorios.DAL;

namespace Obligatorio.Controllers
{
    public class InversorController : Controller
    {
        private PrestamosContext db = new PrestamosContext();

        // GET: Inversor
        public ActionResult Index()
        {
            return View(db.Inversores.ToList());
        }

        // GET: Inversors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inversor inversor = db.Inversores.Find(id);
            if (inversor == null)
            {
                return HttpNotFound();
            }
            return View(inversor);
        }

        // GET: Inversors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inversors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cedula,nombre,apellido,fechaNacimiento,password,celular,email,montoInversion,presentacion")] Inversor inversor)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(inversor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inversor);
        }

        // GET: Inversors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inversor inversor = db.Inversores.Find(id);
            if (inversor == null)
            {
                return HttpNotFound();
            }
            return View(inversor);
        }

        // POST: Inversors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cedula,nombre,apellido,fechaNacimiento,password,celular,email,montoInversion,presentacion")] Inversor inversor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inversor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inversor);
        }

        // GET: Inversors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inversor inversor = db.Inversores.Find(id);
            if (inversor == null)
            {
                return HttpNotFound();
            }
            return View(inversor);
        }

        // POST: Inversors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Inversor inversor = db.Inversores.Find(id);
            db.Usuarios.Remove(inversor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
