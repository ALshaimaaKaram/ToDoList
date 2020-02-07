using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todolistDB.Models.Repositories
{
	public class ToDoDBRepository : IToDoListRepository<todolist>
	{
		todolistDBContext db;

		public ToDoDBRepository(todolistDBContext _db)
		{
			db = _db;
		}

		public void Add(todolist entity)
		{
			db.items.Add(entity);
			db.SaveChanges();
		}

		public void Delete(int id)
		{
			var item = FindById(id);
			db.items.Remove(item);
			db.SaveChanges();
		}

		public todolist FindById(int id)
		{
			var item = db.items.SingleOrDefault(i => i.Id == id);
			return item;
		}

		public IList<todolist> list()
		{
			return db.items.ToList();
		}

		public void Update(todolist entity)
		{
			db.Update(entity);
			db.SaveChanges();
		}
	}
}
