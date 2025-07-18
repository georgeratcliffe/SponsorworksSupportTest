using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SupportEngineerTest.Web.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("ApplicationDbContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .HasRequired(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }

    public class DatabaseInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var users = new List<User>
            {
                new User { Name = "John Smith", Email = "john.smith@company.com", CreatedDate = DateTime.Now.AddDays(-30) },
                new User { Name = "Sarah Johnson", Email = "sarah.johnson@company.com", CreatedDate = DateTime.Now.AddDays(-25) },
                new User { Name = "Mike Wilson", Email = "mike.wilson@company.com", CreatedDate = DateTime.Now.AddDays(-20) },
                new User { Name = "Lisa Brown", Email = "lisa.brown@company.com", CreatedDate = DateTime.Now.AddDays(-15) },
                new User { Name = "David Davis", Email = "david.davis@company.com", CreatedDate = DateTime.Now.AddDays(-10) }
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var random = new Random();
            var statuses = new[] { "Open", "In Progress", "Resolved", "Closed" };
            var priorities = new[] { "Low", "Medium", "High", "Critical" };

            var tickets = new List<Ticket>();
            for (int i = 1; i <= 25; i++)
            {
                tickets.Add(new Ticket
                {
                    Title = $"Support Ticket #{i:D3}",
                    Description = $"This is a sample support ticket description for ticket number {i}. It contains various details about the issue reported by the user.",
                    UserId = users[random.Next(users.Count)].Id,
                    Status = statuses[random.Next(statuses.Length)],
                    Priority = priorities[random.Next(priorities.Length)],
                    CreatedDate = DateTime.Now.AddDays(-random.Next(1, 30)),
                    UpdatedDate = random.Next(2) == 0 ? DateTime.Now.AddDays(-random.Next(1, 15)) : (DateTime?)null
                });
            }

            context.Tickets.AddRange(tickets);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
