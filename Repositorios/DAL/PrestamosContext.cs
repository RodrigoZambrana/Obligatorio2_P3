using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Dominio;

namespace Repositorios.DAL
{
    public class PrestamosContext : DbContext
    {
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Cooperativo> Cooperativos { get; set; }
        public DbSet<Personal> Personales { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Solicitante> Solicitantes { get; set; }


        public DbSet<Inversor> Inversores { get; set; }

        public PrestamosContext() : base("miConexion")
        {

        }

    }
}

