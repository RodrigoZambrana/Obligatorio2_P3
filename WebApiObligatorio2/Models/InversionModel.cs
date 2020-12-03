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
        public string cedulaInversor { get; set; }
        public int idProyecto { get; set; }
        public string tituloProyecto { get; set; }
        public DateTime fechaProyecto { get; set; }
        public decimal montoSolicitado { get; set; }
        public int CantidadCoutas { get; set; }
        public decimal montoConIntereses { get; set; }
        public decimal tasaAplicada { get; set; }
        public string cedulaSolicitante { get; set; }
        public string apellidoSolictante { get; set; }
        public DateTime fechaHoraInversion { get; set; }
        public decimal montoInversion { get; set; }

    }
}