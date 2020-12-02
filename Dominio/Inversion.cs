using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Table("Inversiones")]
   public class Inversion
    {
        [Key]
        public int id;
        [Required]
        public int proyectoId { get; set; }
        [Required]
        public DateTime fechaHora{ get; set; }
        [Required]
        public decimal montoInversion { get; set; }

    }
}
