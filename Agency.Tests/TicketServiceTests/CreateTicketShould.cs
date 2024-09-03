using Agency.Data.Models;
using Agency.Services.Services;
using Agency.Web.Fetching_models;

namespace Agency.Tests.TicketServiceTests
{
    [TestClass]
    public class CreateTicketShould
    {
        [TestMethod]
        public async Task CreateTicketShould_Succeed()
        {
            var nameOfDb =  Guid.NewGuid().ToString();
            var expected = new TicketInputDTO
            {
                Price = 11.11m,
                AdministrativeCosts = 1.11m,
                JourneyId = 1
            };

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new TicketService(assertContext);
                await sut.CreateTicketAsync(expected);
                var result = assertContext.Tickets.OrderBy(x => x.Id).Last();
                Assert.AreEqual(expected.Price, result.Price);
                Assert.AreEqual(expected.AdministrativeCosts, result.AdministrativeCosts);
                Assert.AreEqual(expected.JourneyId, result.JourneyId);
            }
        }

        //[TestMethod]
        //public async Task CreateTicketShould_Fail_InvalidData()
        //{
        //    var nameOfDb =  Guid.NewGuid().ToString();
        //    var dto = new TicketInputDTO
        //    {
        //        Price = -11.11m,
        //        AdministrativeCosts = -1.11m,
        //        JourneyId = 1
        //    };

        //    using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
        //    {
        //        Utils.Seed(arrangeContext);
        //    }

        //    using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
        //    {
        //        var sut = new TicketService(assertContext);
        //        await Assert.ThrowsExceptionAsync<ArgumentException>
        //            (async () => await sut.CreateTicketAsync(dto));
        //    }
        //}
    }
}
