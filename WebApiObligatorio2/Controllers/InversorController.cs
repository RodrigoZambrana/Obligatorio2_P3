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
        RepositorioUsuarios repoUsuarios = new RepositorioUsuarios();
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
           
            if (repoUsuarios.Add(unInversor))

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
    }
}
