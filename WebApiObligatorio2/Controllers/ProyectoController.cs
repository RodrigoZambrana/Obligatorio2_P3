﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dominio;
using Repositorios;

namespace WebApiObligatorio2.Controllers
{
    public class ProyectoController : ApiController
    {
        RepositorioProyectos repoProy = new RepositorioProyectos();
        // GET: api/Proyecto
        public IHttpActionResult Get()


        {

            var proyectos = repoProy.FindAll();
            if (proyectos != null)
            {
                return Ok(proyectos);
            }
            else
                return NotFound();

           
        }
        [Route ("api/proyecto/solicitante/{cedula}")]
        // GET: api/Proyecto/5
        public IHttpActionResult GetPorCedula(string cedula)
        {
            var proyectos = repoProy.FindProyectoPorUsuario(cedula);
            if (proyectos != null)
            {
                return Ok(proyectos);
            }
            else
                return NotFound();

        }

        [HttpGet]
        [Route("api/proyecto/busqueda")]
        public IHttpActionResult Buscar([FromUri] Models.BusquedaModel datos)
        {
            //Búsqueda por refinaciones sucesivas (AND)
            var resultado = repoProy.Buscar(datos.fechaIni, datos.fechaFin, datos.cedula, datos.titulo, datos.descripcion,datos.estado, datos.monto);
            if (resultado != null)
            {
                return Ok(resultado.Select(p => new Models.ProyectoModel
                {
                    id=p.id,
                    cedula=p.cedula,
                    titulo = p.titulo,
                    descripcion = p.descripcion,
                    monto = p.monto,
                    cuotas = p.cuotas,
                    rutaImagen = p.rutaImagen,
                    estado=p.estado,
                    fechaPresentacion=p.fechaPresentacion,
                }).ToList());
            }
            else
                return NotFound();
        }

        [HttpPut]

        [Route("api/proyecto/update/{id}")]
        public IHttpActionResult Put(int id, [FromBody] Proyecto unProyecto)
        {
            if (unProyecto == null)
                return BadRequest();
            if (unProyecto != null)
            {
                if (repoProy.Update(unProyecto))
                   return Ok(repoProy);
                else
                  return BadRequest();
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Proyecto
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Proyecto/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Proyecto/5
        public void Delete(int id)
        {
        }




    }
}
