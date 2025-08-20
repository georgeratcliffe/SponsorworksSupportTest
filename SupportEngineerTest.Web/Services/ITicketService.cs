using SupportEngineerTest.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportEngineerTest.Web.Services
{
	public interface ITicketService
	{
		Task<List<Ticket>> GetAll();

		Task<Ticket> GetById(int id);

		Task Create(Ticket ticket);

		Task Update(Ticket ticket);

		Task Delete(int id);

		void Dispose();
	}
}
