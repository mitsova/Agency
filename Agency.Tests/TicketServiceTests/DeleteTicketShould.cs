using Agency.Data.Models;
using Agency.Services.Services;

namespace Agency.Tests.TicketServiceTests
{
    [TestClass]
    public class DeleteTicketShould
    {
        [TestMethod]
        public async Task DeleteTicketShould_Return_True()
        {
            var nameOfDb =  Guid.NewGuid().ToString();
            var idToDelete = 1;
            
            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new TicketService(assertContext);

                Assert.IsTrue(await sut.DeleteTicketAsync(idToDelete));
                Assert.IsNull(assertContext.Tickets.FirstOrDefault(x => x.Id == idToDelete));
            }
        }

        [TestMethod]
        public async Task DeleteTicketShould_Return_False_Invalid_Id()
        {
            var nameOfDb =  Guid.NewGuid().ToString();
            var invalidId = 0;
            
            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new TicketService(assertContext);

                Assert.IsFalse(await sut.DeleteTicketAsync(invalidId));
            }
        }
    }
}
