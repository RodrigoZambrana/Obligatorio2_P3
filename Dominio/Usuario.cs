using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    [Table("Usuarios")]
    public class Usuario
	{
        [Required]
        [Key]
        public String cedula{ get; set; }

        [Required]
        public String nombre{ get; set; }

        [Required]
        public String apellido{ get; set; }// nuevo cambio

        [Required]
        public DateTime fechaNacimiento { get; set; } //hola algo nuevo

        [Required]
        public string password{ get; set; } //cambio rodrigo


        public bool Validar()
        {
            return true;
        }

        public int Edad()
        {
            int anios = 0;
            anios = DateTime.Now.Year - this.fechaNacimiento.Year;
            return anios;
        }

    }

}

