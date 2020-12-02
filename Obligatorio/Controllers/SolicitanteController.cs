using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Obligatorio.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

namespace Obligatorio.Controllers
{
    //a mi me funca
    public class SolicitanteController : Controller
    {
        HttpClient cliente = new HttpClient();
        HttpResponseMessage response = new HttpResponseMessage();
        Uri proyectoUri = null;

        public SolicitanteController()
        {
            cliente.BaseAddress = new Uri("http://localhost:31069");
            proyectoUri = new Uri("http://localhost:52230/api/proyecto");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(
       new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Productos
        public ActionResult Index()
        {
            string cedula = (string)Session["usuario"];
            response = cliente.GetAsync(proyectoUri+"/solicitante/"+cedula).Result;
            if (response.IsSuccessStatusCode)
            {
                var proys = response.Content.ReadAsAsync<IEnumerable<Models.ProyectoModel>>().Result;
                /*   var lista = prods.Select
                       (p => new Models.ProductoModel { Nombre = p.Nombre, Precio = p.Precio, Id = p.Id });*/

                if (proys != null && proys.Count() > 0)
                    return View("Index", proys.ToList());
                else
                {
                    TempData["ResultadoOperacion"] = "No hay productos disponibles";
                    return View("Index", new List<ProyectoModel>());
                }
            }
            else
            {
                TempData["ResultadoOperacion"] = "Error desconocido";
                return View("Index");
            }
        }

        //Inversor/Filtrar
        public ActionResult Filtrar(DateTime? fechaini, DateTime? fechaFin, string titulo, string descripcion, string estado, decimal? monto)
        {
            string cedula = (string)Session["usuario"];
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



    
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        TempData["ResultadoOperacion"] = "Debe incluir un Id";
        //        return View("Index");
        //    }
        //    response = cliente.GetAsync(productoUri + "/" + id).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var prod = response.Content.ReadAsAsync<Models.ProductoModel>().Result;
        //        return View(prod);
        //    }
        //    else
        //    {
        //        ViewBag.ResultadoOperacion = "No se puede encontrar el producto con el id " + id;
        //        return View();
        //    }
        //}

        //public ActionResult GetByName(string name)
        //{
        //    response = cliente.GetAsync(productoUri + "/getByName/" + name).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var prod = response.Content.ReadAsAsync<Models.ProductoModel>().Result;
        //        return View(prod);
        //    }
        //    else
        //    {
        //        ViewBag.ResultadoOperacion = "No se puede encontrar el producto con el nombre " + name;
        //        return View();
        //    }
        //}
        //public ActionResult Create()
        //{


        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(ProductoModel prod)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        //cliente.BaseAddress = productoUri;

        //        var tareaPost = cliente.PostAsJsonAsync(productoUri, prod);

        //        var result = tareaPost.Result;

        //        if (result.IsSuccessStatusCode)
        //        {
        //            TempData["ResultadoOperacion"] = "Agregado el producto ";
        //            return RedirectToAction("Index");
        //        }
        //        return View(prod);
        //    }
        //    else
        //    {
        //        TempData["ResultadoOperacion"] = "Ups! Verifique los datos";

        //        return RedirectToAction("Index");
        //    }
        //}
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        ViewBag.ResultadoOperacion = "No te olvidaste de algo??";
        //        return View();
        //    }
        //    response = cliente.GetAsync(productoUri + "/" + id.ToString()).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var prod = response.Content.ReadAsAsync<Models.ProductoModel>().Result;
        //        return View(prod);
        //    }
        //    else
        //    {
        //        ViewBag.ResultadoOperacion = "No se puede encontrar el producto con el id " + id;
        //        return View();
        //    }
        //}
        //[HttpPost]
        //public ActionResult Edit(Models.ProductoModel prod)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var tareaPost = cliente.PutAsJsonAsync(productoUri + "/update/" + prod.Id, prod);

        //        var result = tareaPost.Result;

        //        if (result.IsSuccessStatusCode)
        //        {
        //            TempData["ResultadoOperacion"] = "Modificado";
        //            return RedirectToAction("Index");
        //        }
        //        ViewBag.ResultadoOperación = "Ups! Verifique los datos";

        //        return View(prod);
        //    }
        //    else
        //    {
        //        ViewBag.ResultadoOperación = "Ups! Verifique los datos";

        //        return View(prod);
        //    }
        //}
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    response = cliente.GetAsync(productoUri + "/" + id.ToString()).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var prod = response.Content.ReadAsAsync<Models.ProductoModel>().Result;
        //        return View(prod);
        //    }
        //    else
        //    {
        //        ViewBag.ResultadoOperacion = "No se puede encontrar el producto con el id " + id;
        //        return View();
        //    }
        //}

        //// POST: ProductoModels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    var tareaPost = cliente.DeleteAsync(productoUri + "/delete/" + id);

        //    var result = tareaPost.Result;

        //    if (result.StatusCode == HttpStatusCode.NoContent)
        //    {
        //        TempData["ResultadoOperacion"] = "El producto con el Id=" + id + " fue eliminado";
        //        return RedirectToAction("Index");

        //    }
        //    TempData["ResultadoOperacion"] = "Ups! No se pudo eliminar";
        //    return RedirectToAction("Index");
        //}



    }
}