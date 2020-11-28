using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorios.DAL;

namespace Repositorios
{
    public class RepositorioProyectos : IRepositorio<Proyecto>
    {
        private PrestamosContext db = new PrestamosContext();

        public bool Add(Proyecto unT)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Proyecto> FindAll()
        {
            try
            {
                using (db)
                {
                    IEnumerable<Proyecto> losProyectos =
                        db.Proyectos.ToList();
                    return losProyectos;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Proyecto FindById(object clave)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Proyecto unT)
        {
            throw new NotImplementedException();
        }

        public bool Update(Proyecto unT)
        {
            throw new NotImplementedException();
        }
    }



}

