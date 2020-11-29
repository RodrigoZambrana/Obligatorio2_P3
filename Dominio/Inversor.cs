using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Table("Inversores")]
    public class Inversor : Usuario
    {
        [Required]
        public string celular { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public double montoInversion { get; set; }

        [StringLength(500, ErrorMessage = "La presentación no puede tener mas de 500 caracteres")]
        public string presentacion { get; set; }

    }
}