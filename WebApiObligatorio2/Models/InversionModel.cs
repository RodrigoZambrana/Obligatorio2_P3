using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiObligatorio2.Models
{
    public class InversionModel
    {
        public int id { get; set; }
        public Inversor unInversor { get; set; }
        public Proyecto unProyecto { get; set; }
        public DateTime fechaHora { get; set; }
        public decimal montoInversion { get; set; }

    }
}