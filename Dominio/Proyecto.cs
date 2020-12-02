using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using Dominio;

namespace Dominio
{
    [Table("Proyectos")]
    public class Proyecto
	{
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Required]
        public string titulo{ get; set; }
        [Required]
        public string descripcion{ get; set; }
        [Required]
        public decimal monto{ get; set; }
        //monto que se irá descontando a medida que se realicen inversiones
        public decimal montoRestante { get; set; }
        [Required]
        public int cuotas{ get; set; }
        [Required]
        public string rutaImagen{ get; set; }
        public string estado { get; set; } = "ABIERTO";
        public DateTime fechaPresentacion { get; set; } = DateTime.Now;
        [Required]
        public int puntaje { get; set; } = 0;
        [Required]
        public decimal tasaInteres{ get; set; }
        private cambioEstado cambioEstado;
        public Solicitante solicitante { get; set; }
        public string cedula { get; set; }


        public void setSolicitante(Solicitante u)
        {
            this.solicitante = u;
        }

        public bool Validar()
        {
            return true;
        }

        public bool SubirArchivoGuardarNombre(HttpPostedFileBase Archivo)
        {
            if (Archivo != null)
            {
                if (guardarArchivo(Archivo))
                {
                    this.rutaImagen = Archivo.FileName;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Guarda en disco el archivo subido mediante upload
        /// </summary>
        /// <param name="archivo">El archivo subido mediante un input file. 
        /// Debe ser un objeto HttpPostedFileBase. Cuidado no confundir con HttpPostedFile </param>
        /// <returns>True si todo funcionó, false en caso contrario.</returns>
        /// <remarks>Deberían capturarse las excepciones.</remarks>
        private bool guardarArchivo(HttpPostedFileBase archivo)
        {
            if (archivo != null)
            {
                string ruta = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/fotos");
                if (!System.IO.Directory.Exists(ruta))
                    System.IO.Directory.CreateDirectory(ruta);
                ruta = System.IO.Path.Combine(ruta, archivo.FileName);
                archivo.SaveAs(ruta);
                return true;
            }
            else
                return false;
        }


    }

}

