using Agency.Data.Models;
using Agency.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.TrainServiceTests
{
    [TestClass]
    public class DeleteTrainShould
    {
        [TestMethod]
        public async Task DeleteTrainShould_Return_True()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var idToDelete = 1;

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using(var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new TrainService(assertContext);

                Assert.IsTrue(await sut.DeleteTrainAsync(idToDelete));  
            }
        }

        [TestMethod]
        public async Task DeleteTrainShoud_Return_False()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var invalidId = 0;

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using(var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new TrainService(assertContext);

                Assert.IsFalse(await sut.DeleteTrainAsync(invalidId));  
            }
        }
    }
}
