using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using SupportEngineerTest.Web.Models;

namespace SupportEngineerTest.Web.Services
{
    public class TicketService
    {
        private readonly ApplicationDbContext _context;

        public TicketService()
        {
            _context = new ApplicationDbContext();
        }

        public List<Ticket> GetAll()
        {
            return _context.Tickets.ToList();
        }

        public Ticket GetById(int id)
        {
            return _context.Tickets.First(t => t.Id == id);
        }

        public void Create(Ticket ticket)
        {
            var connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\SupportEngineerTest.mdf;Initial Catalog=SupportEngineerTest;Integrated Security=True";
            var connection = new SqlConnection(connectionString);
            connection.Open();
            
            ticket.CreatedDate = DateTime.Now;
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }

        public void Update(Ticket ticket)
        {
            ticket.UpdatedDate = DateTime.Now;
            _context.Entry(ticket).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var ticket = GetById(id);
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
