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
        Uri inversorUri = null;
        Uri proyectoUri = null;

        public InversorController()
        {
            cliente.BaseAddress = new Uri("http://localhost:31069");
            inversorUri = new Uri("http://localhost:52230/api/inversor");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(
       new MediaTypeWithQualityHeaderValue("application/json"));

            cliente.BaseAddress = new Uri("http://localhost:31069");
            proyectoUri = new Uri("http://localhost:52230/api/proyecto");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(
       new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Inversor
       // [Route("api/inversor/inversiones/{cedula}")]
        public ActionResult Index()
        {
            string cedula = (string)Session["usuario"];
            string ruta = $"{inversorUri}/inversiones/{cedula}";
            Uri uri = new Uri(ruta);
            var response = cliente.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var lista = response.Content.ReadAsAsync<IEnumerable<Models.InversionModel>>().Result;
                ViewBag.Mensaje = $"Se encontraron {lista.Count()} resultados";
                return View(lista);
            }
            ViewBag.Mensaje = "No se encontraron resultados";
            return View();
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

        // GET: Inversor/Details/5
        public ActionResult Financiar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto p = db.Proyectos.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }

            ProyectoModel m = new ProyectoModel
            {
                id = p.id,
                cedula = p.cedula,
                titulo = p.titulo,
                descripcion = p.descripcion,
                monto = p.monto,
                cuotas = p.cuotas,
                rutaImagen = p.rutaImagen,
                estado = p.estado,
                fechaPresentacion = p.fechaPresentacion
            };

            return View(m);
        }

        //public ActionResult InversionesInversor() {
        //    string cedula = (string)Session["usuario"];
        //    string ruta = $"{inversorUri}/inversiones/?cedula={cedula}";
        //    Uri uri = new Uri(ruta);
        //    var response = cliente.GetAsync(uri).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var lista = response.Content.ReadAsAsync<IEnumerable<Inversion>>().Result;
        //        ViewBag.Mensaje = $"Se encontraron {lista.Count()} resultados";
        //        return View(lista);
        //    }
        //    ViewBag.Mensaje = "No se encontraron resultados";
        //    return View();
        //}
    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
    }
