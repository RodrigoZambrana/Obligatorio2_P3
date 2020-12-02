using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Obligatorio.Models;
using Repositorios.DAL;

namespace Obligatorio.Controllers
{
    public class InversorController : Controller
    {
        private PrestamosContext db = new PrestamosContext();
        HttpClient cliente = new HttpClient();
        HttpResponseMessage response = new HttpResponseMessage();
        Uri proyectoUri = null;

        public InversorController()
        {
            cliente.BaseAddress = new Uri("http://localhost:31069");
            proyectoUri = new Uri("http://localhost:52230/api/proyecto");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(
       new MediaTypeWithQualityHeaderValue("application/json"));
        }

            // GET: Inversor
            public ActionResult Index()
        {
            response = cliente.GetAsync(proyectoUri).Result;
            if (response.IsSuccessStatusCode)
            {
                var proys = response.Content.ReadAsAsync<IEnumerable<Models.ProyectoModel>>().Result;
                /*   var lista = prods.Select
                       (p => new Models.ProductoModel { Nombre = p.Nombre, Precio = p.Precio, Id = p.Id });*/

                if (proys != null && proys.Count() > 0)
                    return View("Index", proys.ToList());
                else
                {
                    TempData["ResultadoOperacion"] = "No hay proyectos disponibles";
                    return View("Index", new List<ProyectoModel>());
                }
            }
            else
            {
                TempData["ResultadoOperacion"] = "Error desconocido";
                return View("Index");
            }
        }

        public ActionResult Filtrar()
        {
            return View();
        }

        //Inversor/Filtrar
        [HttpPost]
        public ActionResult Filtrar(DateTime? fechaini, DateTime? fechaFin, string cedula, string titulo, string descripcion, string estado, decimal? monto) {
            string ruta = $"{proyectoUri}/busqueda/?fechaIni={fechaini}&fechaFin={fechaFin}&cedula={cedula}&titulo={titulo}&descripcion={descripcion}&estado={estado}&monto={monto}";
            Uri uri = new Uri(ruta);
            var response = cliente.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var lista = response.Content.ReadAsAsync<IEnumerable<ProyectoModel>>().Result;
                ViewBag.Mensaje = $"Se encontraron {lista.Count()} resultados";
                return View(lista);
            }
            ViewBag.Mensaje = "No se encontraron resultados";
            return View();
        }












        //    // GET: Inversors/Details/5
        //    public ActionResult Details(string id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Inversor inversor = db.Inversores.Find(id);
        //        if (inversor == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(inversor);
        //    }

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

            //    // GET: Inversors/Edit/5
            //    public ActionResult Edit(string id)
            //    {
            //        if (id == null)
            //        {
            //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //        }
            //        Inversor inversor = db.Inversores.Find(id);
            //        if (inversor == null)
            //        {
            //            return HttpNotFound();
            //        }
            //        return View(inversor);
            //    }

            //    // POST: Inversors/Edit/5
            //    // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
            //    // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
            //    [HttpPost]
            //    [ValidateAntiForgeryToken]
            //    public ActionResult Edit([Bind(Include = "cedula,nombre,apellido,fechaNacimiento,password,celular,email,montoInversion,presentacion")] Inversor inversor)
            //    {
            //        if (ModelState.IsValid)
            //        {
            //            db.Entry(inversor).State = EntityState.Modified;
            //            db.SaveChanges();
            //            return RedirectToAction("Index");
            //        }
            //        return View(inversor);
            //    }

            //    // GET: Inversors/Delete/5
            //    public ActionResult Delete(string id)
            //    {
            //        if (id == null)
            //        {
            //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //        }
            //        Inversor inversor = db.Inversores.Find(id);
            //        if (inversor == null)
            //        {
            //            return HttpNotFound();
            //        }
            //        return View(inversor);
            //    }

            //    // POST: Inversors/Delete/5
            //    [HttpPost, ActionName("Delete")]
            //    [ValidateAntiForgeryToken]
            //    public ActionResult DeleteConfirmed(string id)
            //    {
            //        Inversor inversor = db.Inversores.Find(id);
            //        db.Usuarios.Remove(inversor);
            //        db.SaveChanges();
            //        return RedirectToAction("Index");
            //    }

            //    protected override void Dispose(bool disposing)
            //    {
            //        if (disposing)
            //        {
            //            db.Dispose();
            //        }
            //        base.Dispose(disposing);
            //    }
        }
}
