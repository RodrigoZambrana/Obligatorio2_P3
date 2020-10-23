using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Dominio;
using Repositorios;

namespace ServiciosProyecto
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiciosProyecto : IServicioProyecto
    {
        public IEnumerable<ProyectoDTO> todosLosproyectos()
        {
            IEnumerable<Proyecto> listaProyectos = (new RepositorioProyectos().FindAll());
            if (listaProyectos == null) return null;
            List<ProyectoDTO> listaProyectosDTO = new List<ProyectoDTO>();
            foreach (Proyecto p in listaProyectos)
            {
                listaProyectosDTO.Add(ConvertirAProyectoDTO(p));
            }
            return listaProyectosDTO;
        }

        ProyectoDTO ConvertirAProyectoDTO(Proyecto p) {
            if (p == null) return null;
            ProyectoDTO pdto = new ProyectoDTO
            {
                titulo=p.titulo,
                descripcion=p.descripcion,
                monto=p.monto
            };
            return pdto;

        }
    }
}

