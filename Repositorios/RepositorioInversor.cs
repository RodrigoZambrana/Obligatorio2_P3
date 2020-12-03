using Dominio;
using Repositorios.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Repositorios
{
    public class RepositorioInversor : IRepositorio<Inversor>
    {
        private PrestamosContext db = new PrestamosContext();
        public bool Add(Inversor unT)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Inversor> FindAll()
        {
            throw new NotImplementedException();
        }

        public Inversor FindById(object clave)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Inversor unT)
        {
            throw new NotImplementedException();
        }

        public bool Update(Inversor unT)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Inversion> FindInversionesPorInversor(string cedula)
        {
            try
            {
                using (db)
                {
                    IEnumerable<Inversion> Inversiones = db.Inversiones.Where(i => i.Inversor_cedula == cedula)
                        .Include(i=>i.unProyecto.solicitante).ToList();
                    return Inversiones;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}
