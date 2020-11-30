using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Obligatorio.Models
{
    public class ProyectoModel

    {
        public string titulo { get; set; }
        [Required]
        public string descripcion { get; set; }
        [Required]
        public decimal monto { get; set; }
        [Required]
        public int cuotas { get; set; }
        [Required]
        public string rutaImagen { get; set; }
        public string estado { get; set; } 
        public DateTime fechaPresentacion { get; set; }
        [Required]
        public int puntaje { get; set; }
    }
}