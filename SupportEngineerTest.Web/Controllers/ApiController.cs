using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using SupportEngineerTest.Web.Models;
using SupportEngineerTest.Web.Services;

namespace SupportEngineerTest.Web.Controllers
{
    [RoutePrefix("api")]
    public class TicketsController : ApiController
    {
        private readonly ITicketService _ticketService;

        public TicketsController()
        {
        }

		public TicketsController(ITicketService ticketService)
		{
			_ticketService = ticketService;
		}

		[HttpGet]
        [Route("tickets")]
        public async Task<IHttpActionResult> GetTickets()
        {
            System.Web.HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache");
            var tickets = await _ticketService.GetAll();
            return Ok(tickets);
        }

        [HttpPost]
        [Route("tickets")]
        public IHttpActionResult CreateTicket([FromBody] Ticket ticket)
        {
            System.Web.HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache");
            if (ModelState.IsValid)
            {
                _ticketService.Create(ticket);
                return Ok(ticket);
            }
            return BadRequest(ModelState);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _ticketService?.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
