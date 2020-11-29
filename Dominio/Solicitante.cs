using Dominio;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    [Table("Solicitantes")]
    public class Solicitante : Usuario
	{
        [Required]
        public string celular{ get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string email{ get; set; }

	}

}

