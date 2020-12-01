using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiObligatorio2.Models
{
    public class BusquedaModel
    {
        public DateTime fechaIni { get; set; }
        public DateTime fechaFin { get; set; }
        public string cedula { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
        public decimal monto { get; set; }
    }
}