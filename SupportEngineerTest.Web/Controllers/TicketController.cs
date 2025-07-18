using System;
using System.Linq;
using System.Web.Mvc;
using SupportEngineerTest.Web.Models;
using SupportEngineerTest.Web.Services;
using System.Threading.Tasks;

namespace SupportEngineerTest.Web.Controllers
{
    public class TicketController : Controller
    {
        private readonly TicketService _ticketService;

        public TicketController()
        {
            _ticketService = new TicketService();
        }

        public async Task<ActionResult> Index()
        {
            var tickets = _ticketService.GetAll().Take(10).ToList();
            return View(tickets);
        }

        public async Task<ActionResult> Details(int id)
        {
            var ticket = _ticketService.GetById(id);
            return View(ticket);
        }

        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Ticket ticket)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ticketService.Create(ticket);
                }
            }
            catch (Exception)
            {
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
