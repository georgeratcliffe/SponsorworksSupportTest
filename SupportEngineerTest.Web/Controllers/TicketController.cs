using System;
using System.Linq;
using System.Web.Mvc;
using SupportEngineerTest.Web.Models;
using SupportEngineerTest.Web.Services;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SupportEngineerTest.Web.Controllers
{
	public class TicketController : Controller
	{
		private readonly ITicketService _ticketService;

		public TicketController()
		{
		}

		public TicketController(ITicketService ticketService)
		{
			_ticketService = ticketService;
		}

		public async Task<ActionResult> Index()
		{
			var tickets = await _ticketService.GetAll();
			return View(tickets.Take(10));
		}

		public async Task<ActionResult> Details(int id)
		{
			var ticket = await _ticketService.GetById(id);
			return View(ticket);
		}

		public async Task<ActionResult> Create()
		{
			await Task.CompletedTask;
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> Create(Ticket ticket)
		{
			try
			{
				if (ModelState.IsValid)
					await _ticketService.Create(ticket);
				else
					return View(ticket);
			}
			catch (Exception ex)
			{
				var error = new HandleErrorInfo(ex, "TicketController", "Create");

				return View("~/Views/Shared/Error", error);
			}

			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_ticketService?.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
