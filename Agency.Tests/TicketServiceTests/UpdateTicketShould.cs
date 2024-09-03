using Agency.Data.Models;
using Agency.Services.Services;
using Agency.Web.Fetching_models;

namespace Agency.Tests.TicketServiceTests
{
    [TestClass]
    public class UpdateTicketShould
    {
        [TestMethod]
        public async Task UpdateTicketShould_Succeed()
        {
            var nameOfDb = Guid.NewGuid().ToString();

            var idToUpdate = 1;
            var expected = new TicketInputDTO
            {
                Price = 123.45m,
                AdministrativeCosts= 6.9m
            };

            using(var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using(var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new TicketService(assertContext);
                await sut.UpdateTicketAsync(idToUpdate, expected);

                var result = assertContext.Tickets.Where(x  => x.Id == idToUpdate).First();
                Assert.AreEqual(result.Id, idToUpdate);
                Assert.AreEqual(expected.Price, result.Price);
                Assert.AreEqual(expected.AdministrativeCosts, result.AdministrativeCosts);
            }
        }

        [TestMethod]
        public async Task UpdateTicketShould_Throw_Null()
        {
            var nameOfDb = Guid.NewGuid().ToString();

            using(var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using(var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new TicketService(assertContext);
                _ = await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await sut.UpdateTicketAsync(1234, new TicketInputDTO()));
            }
        }
    }
}
