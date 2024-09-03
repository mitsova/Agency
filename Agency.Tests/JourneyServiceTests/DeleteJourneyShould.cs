using Agency.Data.Models;
using Agency.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.JourneyServiceTests
{
    [TestClass]
    public class DeleteJourneyShould
    {
        [TestMethod]
        public async Task DeleteJourneyShould_Return_True()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var idToDelete = 1;

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using(var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new JourneyService(assertContext);
                
                Assert.IsTrue(await sut.DeleteJourneyAsync(idToDelete)); 
            }
        }

        [TestMethod]
        public async Task DeleteJourneyShould_Return_False_Ivalid_Id()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var idToDelete = 0;

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using(var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new JourneyService(assertContext);
                
                Assert.IsFalse(await sut.DeleteJourneyAsync(idToDelete)); 
            }
        }
    }
}
