using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dominio;
using Repositorios;

namespace WebApiObligatorio2.Controllers
{
    public class InversorController : ApiController
    {
        RepositorioInversor repoInv = new RepositorioInversor();

        // GET: api/Inversor
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Inversor/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Inversor
        public IHttpActionResult Post([FromBody]Inversor unInversor)
        {     
          if (repoInv.Add(unInversor))

            {
                return (CreatedAtRoute("GetById", new { id = unInversor.cedula }, unInversor));
            }

            else
            {
                return InternalServerError();
            }
        }

        // PUT: api/Inversor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Inversor/5
        public void Delete(int id)
        {
        }


        [Route("api/inversor/inversiones/{cedula}")]
        // GET: api/Inversor/5
        public IHttpActionResult GetPorCedula(string cedula)
        {
            var inversiones = repoInv.FindInversionesPorInversor(cedula);

            if (inversiones != null)
            {

                return Ok(inversiones.Select(i => new Models.InversionModel
                {
                    idProyecto = i.unProyecto.id,
                    tituloProyecto = i.unProyecto.titulo,
                    fechaProyecto = i.unProyecto.fechaPresentacion,
                    montoSolicitado = i.unProyecto.monto,
                    CantidadCoutas = i.unProyecto.cuotas,
                    montoConIntereses = (i.unProyecto.tasaInteres * i.unProyecto.monto / 100) + i.unProyecto.monto,
                   tasaAplicada =i.unProyecto.tasaInteres,
                   cedulaSolicitante=i.unProyecto.cedula,
                   apellidoSolictante=i.unProyecto.solicitante.apellido,
                   montoInversion=i.montoInversion,
                   fechaHoraInversion=i.fechaHora
                }).ToList());
            
            }
            else
                return NotFound();
        }
        
        //public string cedulaSolicitante { get; set; }
        //public string apellidoSolictante { get; set; }
        //public DateTime fechaHoraInversion { get; set; }
        //public decimal montoInversion { get; set; }







        // POST: api/Inversion
        //public IHttpActionResult Inversion([FromBody]Inversion unaInversion)
        //{
        //    repos
        //    if (repoInv.Add(unaInversion))

        //    {
        //        return (CreatedAtRoute("GetById", new { id = unaInversion.cedula }, unaInversion));
        //    }

        //    else
        //    {
        //        return InternalServerError();
        //    }
        //}



    }
}
