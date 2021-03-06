﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Obligatorio.Models
{
    public class ProyectoModel

    {
        public int id { get; set; }
        public string cedula { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }     
        public decimal monto { get; set; }
        public int cuotas { get; set; }   
        public string rutaImagen { get; set; }
        public string estado { get; set; } 
        public DateTime fechaPresentacion { get; set; }      
        public int puntaje { get; set; }
        public string tipo { get; set; }
    }
}