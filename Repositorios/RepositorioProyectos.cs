﻿using System;
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
        public IEnumerable<Proyecto> Buscar(DateTime fechaini, DateTime fechaFin, string cedula, string titulo, string descripcion, string estado, decimal? monto)
        {
            PrestamosContext db = new PrestamosContext();
            var proyectos = from p in db.Proyectos select p;
            if (fechaini != null && fechaFin != null)
            {
                proyectos = proyectos.Where(p => p.fechaPresentacion >= fechaini && p.fechaPresentacion <= fechaFin);
            }

            if (!String.IsNullOrEmpty(cedula))
            {
                proyectos = proyectos.Where(p => p.solicitante.cedula.Contains(cedula));
            }
            if (fechaini != null && fechaFin != null)
            {
                proyectos = proyectos.Where(p => p.fechaPresentacion >= fechaini && p.fechaPresentacion <= fechaFin);
            }
            if (!String.IsNullOrEmpty(titulo))
            {
                proyectos = proyectos.Where(p => p.titulo.Contains(titulo));
            }
            if (!String.IsNullOrEmpty(descripcion))
            {
                proyectos = proyectos.Where(p => p.descripcion.Contains(descripcion));
            }
            if (monto!= null)
            {
                proyectos = proyectos.Where(p => p.monto >= monto);
            }
            return proyectos.ToList();
        }






    }

}

