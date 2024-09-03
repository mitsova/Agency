using Agency.Data.Models;
using Agency.Services.DTOs.OutputDTOs;
using Agency.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.TicketServiceTests
{
    [TestClass]
    public class GetAllTicketsShould
    {
        [TestMethod]
        public async Task GetAllTicketsShould_Return_Collection()
        {
            var nameOfDb = Guid.NewGuid().ToString();

            var expected = new []
            {
                new TicketOutputDTO { Id = 1, Name = $"Ticket 1", Destination = "Sofia", Price = 21.75m, AdministrativeCosts = 4.33m, Img = "https://e7.pngegg.com/pngimages/706/889/png-clipart-ticket-ticket-miscellaneous-template.png"},
                new TicketOutputDTO { Id = 2, Name = $"Ticket 2", Destination = "Sofia", Price = 20.75m, AdministrativeCosts = 4.33m, Img = "https://e7.pngegg.com/pngimages/706/889/png-clipart-ticket-ticket-miscellaneous-template.png"},
                new TicketOutputDTO { Id = 3, Name = $"Ticket 3", Destination = "Sofia", Price = 20.75m, AdministrativeCosts = 4.33m, Img = "https://e7.pngegg.com/pngimages/706/889/png-clipart-ticket-ticket-miscellaneous-template.png"},
                new TicketOutputDTO { Id = 4, Name = $"Ticket 4", Destination = "Sofia", Price = 21.75m, AdministrativeCosts = 4.33m, Img = "https://e7.pngegg.com/pngimages/706/889/png-clipart-ticket-ticket-miscellaneous-template.png"},

                new TicketOutputDTO { Id = 5, Name = $"Ticket 5", AdministrativeCosts = 2.98m, Price = 15.33m, Destination = "Varna", Img = "https://e7.pngegg.com/pngimages/706/889/png-clipart-ticket-ticket-miscellaneous-template.png"},
                new TicketOutputDTO { Id = 6, Name = $"Ticket 6", AdministrativeCosts = 2.98m, Price = 10.33m, Destination = "Varna", Img = "https://e7.pngegg.com/pngimages/706/889/png-clipart-ticket-ticket-miscellaneous-template.png"},
                new TicketOutputDTO { Id = 7, Name = $"Ticket 7", AdministrativeCosts = 2.98m, Price = 10.33m, Destination = "Varna", Img = "https://e7.pngegg.com/pngimages/706/889/png-clipart-ticket-ticket-miscellaneous-template.png"},
                new TicketOutputDTO { Id = 8, Name = $"Ticket 8", AdministrativeCosts = 2.98m, Price = 15.33m, Destination = "Varna", Img = "https://e7.pngegg.com/pngimages/706/889/png-clipart-ticket-ticket-miscellaneous-template.png"},
                new TicketOutputDTO { Id = 9, Name = $"Ticket 9", AdministrativeCosts = 2.98m, Price = 15.33m, Destination = "Varna", Img = "https://e7.pngegg.com/pngimages/706/889/png-clipart-ticket-ticket-miscellaneous-template.png"},

                new TicketOutputDTO { Id = 10, Name = $"Ticket 10", AdministrativeCosts = 6.21m, Price = 78.42m, Destination = "London", Img = "https://e7.pngegg.com/pngimages/706/889/png-clipart-ticket-ticket-miscellaneous-template.png"},
                new TicketOutputDTO { Id = 11, Name = $"Ticket 11", AdministrativeCosts = 6.21m, Price = 78.42m, Destination = "London", Img = "https://e7.pngegg.com/pngimages/706/889/png-clipart-ticket-ticket-miscellaneous-template.png"},
                new TicketOutputDTO { Id = 12, Name = $"Ticket 12", AdministrativeCosts = 6.21m, Price = 78.42m, Destination = "London", Img = "https://e7.pngegg.com/pngimages/706/889/png-clipart-ticket-ticket-miscellaneous-template.png"},
                new TicketOutputDTO { Id = 13, Name = $"Ticket 13", AdministrativeCosts = 6.21m, Price = 78.42m, Destination = "London", Img = "https://e7.pngegg.com/pngimages/706/889/png-clipart-ticket-ticket-miscellaneous-template.png"},
                new TicketOutputDTO { Id = 14, Name = $"Ticket 14", AdministrativeCosts = 6.21m, Price = 78.42m, Destination = "London", Img = "https://e7.pngegg.com/pngimages/706/889/png-clipart-ticket-ticket-miscellaneous-template.png"}
            };

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new TicketService(assertContext);
                var result = (await sut.GetAllTicketsAsync()).ToArray();

                Assert.AreEqual(expected.Length, result.Length);

                for (int i = 0; i < result.Length; i++)
                {
                    Assert.AreEqual(expected[i].Id, result[i].Id);
                    Assert.AreEqual(expected[i].Name, result[i].Name);
                    Assert.AreEqual(expected[i].Destination, result[i].Destination);
                    Assert.AreEqual(expected[i].Price, result[i].Price);
                    Assert.AreEqual(expected[i].AdministrativeCosts, result[i].AdministrativeCosts);
                    Assert.AreEqual(expected[i].Img, result[i].Img);
                }
            }
        }
    }
}
