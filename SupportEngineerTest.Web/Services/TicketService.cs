using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using SupportEngineerTest.Web.Models;

namespace SupportEngineerTest.Web.Services
{
	public class TicketService : ITicketService
	{
		private readonly ApplicationDbContext _context;

		public TicketService()
		{
			_context = new ApplicationDbContext();
		}

		public TicketService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<Ticket>> GetAll()
		{
			return await _context.Tickets.ToListAsync();
		}

		public async Task<Ticket> GetById(int id)
		{
			return await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);
		}

		public async Task Create(Ticket ticket)
		{
			ticket.CreatedDate = DateTime.Now;
			_context.Tickets.Add(ticket);
			await _context.SaveChangesAsync();
		}

		public async Task Update(Ticket ticket)
		{
			ticket.UpdatedDate = DateTime.Now;
			_context.Entry(ticket).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var ticket = await GetById(id);
			if (ticket != null)
			{
				_context.Tickets.Remove(ticket);
				_context.SaveChanges();
			}
		}

		public void Dispose()
		{
			_context?.Dispose();
		}
	}
}
