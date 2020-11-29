using System;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio;

namespace Dominio
{
    [Table ("Cooperativos")]
	public class Cooperativo : Proyecto
	{
		public int cantIntegrantes{ get; set; }

       
    }

}

