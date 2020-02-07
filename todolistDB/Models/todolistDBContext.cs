using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todolistDB.Models
{
	public class todolistDBContext:DbContext
	{
		public todolistDBContext(DbContextOptions<todolistDBContext> options):base(options)
		{

		}

		public DbSet<todolist> items { get; set; }
	}
}
