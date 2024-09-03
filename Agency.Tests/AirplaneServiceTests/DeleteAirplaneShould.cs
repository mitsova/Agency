using Agency.Data.Models;
using Agency.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.AirplaneServiceTests
{
    [TestClass]
    public class DeleteAirplaneShould
    {
        [TestMethod]
        public async Task DeleteAirplaneShould_Return_True()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var IdToDelete = 1;

            using ( var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using(var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new AirplaneService(assertContext);

                Assert.IsTrue(await sut.DeleteAirplaneAsync(IdToDelete));
            }
        }

        [TestMethod]
        public async Task DeleteAirplaneShould_Throw_Null()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var invalidId = 0;

            using(var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using(var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new AirplaneService(assertContext);

                Assert.IsFalse(await sut.DeleteAirplaneAsync(invalidId));
            }
        }
    }
}
