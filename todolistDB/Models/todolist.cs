using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace todolistDB.Models
{
	public class todolist
	{
		[Required]
		public int Id { get; set; }
		public string text { get; set; }
		public bool status { get; set; }
	}
}
