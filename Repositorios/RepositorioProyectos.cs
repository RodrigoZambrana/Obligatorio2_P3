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

        public bool Add(Proyecto objeto)
        {
            if (objeto == null) return false;
            try
            {
                using (db)
                {
                    db.Proyectos.Add(objeto);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
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
            try
            {
                string idProyecto = (string)clave;
                using (db)
                {
                    Proyecto unProyecto = db.Proyectos.Find(idProyecto);
                    return unProyecto;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public bool Remove(Proyecto clave)
        {
            try
            {
                int idProyecto = (int)clave.id;
                using (db)
                {
                    Proyecto unProyecto = db.Proyectos.Find(idProyecto);
                    if (unProyecto != null)
                    {
                        db.Proyectos.Remove(unProyecto);
                        db.SaveChanges();
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool Update(Proyecto objeto)
        {
            if (objeto == null) return false;
            try
            {

                using (db)
                {
                    db.Entry(objeto).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }



        }
        public IEnumerable<Proyecto> FindProyectoPorUsuario(string cedula)
        {
            try
            {
                
                using (db)
                {
                IEnumerable<Proyecto>  unProyecto = db.Proyectos.Where(p=>p.solicitante.cedula==cedula).ToList();
                    return unProyecto;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }



}

