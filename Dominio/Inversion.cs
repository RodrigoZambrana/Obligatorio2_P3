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
        [Required]
        [Key]
        public int id { get; set; }
        [ForeignKey("unProyecto")] public int idProyecto { get; set; }
        public Proyecto unProyecto { get; set; }
        [Required]
        public DateTime fechaHora{ get; set; }
        [Required]
        public decimal montoInversion { get; set; }



    }
}
