using Moq;
using SupportEngineerTest.Web.Models;
using SupportEngineerTest.Web.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SupportEngineerTest.Tests
{
    public class TicketServiceTests
    {

		Mock<System.Data.Entity.DbSet<Ticket>> mockSet = new Mock<System.Data.Entity.DbSet<Ticket>>();

		IQueryable<Ticket> tickets = new List<Ticket>
				{
				new Ticket { Id = 1, UserId = 1, User= new User(), Title = "tick1", Description="desc1", Status="Brought", Priority="High", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
				new Ticket { Id = 2, UserId = 2, User= new User(), Title = "tick2", Description="desc2", Status="Sold", Priority="Low", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now }
			}.AsQueryable();

		public TicketServiceTests()
		{
			mockSet.As<IDbAsyncEnumerable<Ticket>>()
			   .Setup(m => m.GetAsyncEnumerator())
			   .Returns(new TestDbAsyncEnumerator<Ticket>(tickets.GetEnumerator()));

			mockSet.As<IQueryable<Ticket>>()
				.Setup(m => m.Provider)
				.Returns(new TestDbAsyncQueryProvider<Ticket>(tickets.Provider));

			mockSet.As<IQueryable<Ticket>>().Setup(m => m.Expression).Returns(tickets.Expression);
			mockSet.As<IQueryable<Ticket>>().Setup(m => m.ElementType).Returns(tickets.ElementType);
			mockSet.As<IQueryable<Ticket>>().Setup(m => m.GetEnumerator()).Returns(() => tickets.GetEnumerator());

		}


		//[Fact(Skip = "TODO: Implement proper unit tests with mocking")]
		[Fact]
		public async Task GetAll_ShouldReturnAllTickets()
        {

			var mockDbContext = new Mock<ApplicationDbContext>();
			mockDbContext.Setup(x => x.Tickets).Returns(() => mockSet.Object);
            var service = new TicketService(mockDbContext.Object);

            var result = await service.GetAll();

			Assert.Equal(tickets.ToList(), result);
		}

		[Fact]
        public async Task GetById_ShouldReturnCorrectTicket()
        {
			var ticketId = 2;
			var mockDbContext = new Mock<ApplicationDbContext>();
			mockDbContext.Setup(x => x.Tickets).Returns(() => mockSet.Object);
			var service = new TicketService(mockDbContext.Object);

			var result = await service.GetById(ticketId);

			Assert.Equal(tickets.SingleOrDefault(x => x.Id == ticketId), result);
		}

		// Error handling shoud be handled at controller level
        [Fact(Skip = "TODO: Test error handling scenarios")]
        public void Create_ShouldAddNewTicket()
        {
            Assert.True(true);
        }
    }
}
