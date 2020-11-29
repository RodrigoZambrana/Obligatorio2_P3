using Dominio;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    [Table("Personales")]
    public class Personal : Proyecto
	{
		public string experiencia{ get; set; }

	}

}

