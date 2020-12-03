using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio.Models
{
    public class InversionModel
    {
        public int id { get; set; }
        public string cedulaInversor { get; set; }
        public int idProyecto { get; set; }
        public DateTime fechaHora { get; set; }
        public decimal montoInversion { get; set; }

    }
}