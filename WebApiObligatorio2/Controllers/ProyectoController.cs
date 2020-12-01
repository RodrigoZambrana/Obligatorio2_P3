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
