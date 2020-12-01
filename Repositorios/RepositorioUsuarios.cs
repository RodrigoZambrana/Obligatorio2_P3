using Dominio;
using Repositorios.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class RepositorioUsuarios : IRepositorio<Usuario>
    {
        public bool Add(Usuario objeto)

        {
            try
            {
                if (objeto != null && objeto.Validar())
                {
                    using (PrestamosContext db = new PrestamosContext())
                    {
                        db.Usuarios.Add(objeto);
                        db.SaveChanges();
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public IEnumerable<Usuario> FindAll()

        {
            using (PrestamosContext db = new PrestamosContext())
            {
                return db.Usuarios.ToList();
            }
        }

        public Usuario FindById(object clave)
        {

            using (PrestamosContext db = new PrestamosContext())

            {

                return db.Usuarios.Find((string)clave);

            }

        }



        public bool Remove(object clave)

        {

            throw new NotImplementedException();

        }

        public bool Remove(Usuario unT)
        {
            throw new NotImplementedException();
        }

        public bool Update(Usuario objeto)

        {

            throw new NotImplementedException();

        }



    
    }
}
