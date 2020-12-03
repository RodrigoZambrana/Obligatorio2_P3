using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApiObligatorio2.Models
{
    public class InvertirModel
    {
        public string tituloProyecto { get; set; }
        public string tipoProyecto { get; set; }
        public DateTime fechaProyecto { get; set; }
        public Solicitante solicitante { get; set; }
        public Proyecto poryecto { get; set; }
        public decimal montoSolicitadoConIntereses { get; set; }
        public int montoCuotaIntereses { get; set; }
    }
}