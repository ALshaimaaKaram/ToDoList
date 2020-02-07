using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todolistDB.Models;
using todolistDB.Models.Repositories;

namespace todolistDB.Controllers
{
	public class ToDoController : Controller
	{
		private readonly IToDoListRepository<todolist> toDoListRepository;
		//List<todolist> finishedList;
		private readonly IToDoListRepository<todolist> finishedList;

		public ToDoController(IToDoListRepository<todolist> toDoListRepository)
		{
			this.toDoListRepository = toDoListRepository;
		}


		// GET: ToDo
		public ActionResult Index()
		{
			var items = toDoListRepository.list();

			return View(items);
		}

		// GET: ToDo/Details/5
		public ActionResult Details(int id)
		{
			var item = toDoListRepository.FindById(id);

			return View(item);
		}

		// GET: ToDo/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ToDo/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(todolist items)
		{
			try
			{
				// TODO: Add insert logic here
				toDoListRepository.Add(items);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: ToDo/Edit/5
		public ActionResult Edit(int id)
		{
			var item = toDoListRepository.FindById(id);

			return View(item);
		}

		// POST: ToDo/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, todolist item)
		{
			try
			{
				// TODO: Add update logic here
				toDoListRepository.Update(item);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: ToDo/Delete/5
		public ActionResult Delete(int id)
		{
			var item = toDoListRepository.FindById(id);

			return View(item);
		}

		// POST: ToDo/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, todolist items)
		{
			try
			{
				// TODO: Add delete logic here
				toDoListRepository.Delete(id);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		//POST: ToDo/MarkDone
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult MarkDone(int id) //to change single note status
		{
			try
			{
				var item = toDoListRepository.FindById(id);
				item.status = !item.status;
				toDoListRepository.Update(item);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}

			//return View(item);
		}
		

		public ActionResult ListFinished()
		{
			//var itemsFinished = finishedList.list();
			var doneItems = toDoListRepository.list().Where(c => c.status == true);
			return View(doneItems);
		}
	}
}