using Agency.Data.Models;
using Agency.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.BusServiceTests
{
    [TestClass]
    public class DeleteBusShould
    {
        [TestMethod]
        public async Task DeleteBusShould_Return_True()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var idToDelete = 1;

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new BusService(assertContext);

                Assert.IsTrue(await sut.DeleteBusAsync(idToDelete));
            }
        }

        [TestMethod]
        public async Task DeleteBusShould_Return_False()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var invalidId = 0;

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new BusService(assertContext);

                Assert.IsFalse(await sut.DeleteBusAsync(invalidId));
            }
        }
    }
}
