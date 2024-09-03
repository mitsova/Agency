using Agency.Data.Models;
using Agency.Services.Services;
using Agency.Web.Fetching_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.JourneyServiceTests
{
    [TestClass]
    public class UpdateJourneyShould
    {
        [TestMethod]
        public async Task UpdateJourneyShould_Succeed()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var idToUpdate = 1;

            var expected = new JourneyInputDTO
            {
                StartLocation = "Kaspichan",
                Destination = "Sopot",
                Distance = 666,
                TravelCosts = 420.69m
            };

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using(var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new JourneyService(assertContext);
                await sut.UpdateJourneyAsync(idToUpdate, expected);

                var result = assertContext.Journeys.Where(x => x.Id == idToUpdate).First();  
                Assert.AreEqual(expected.StartLocation, result.StartLocation);
                Assert.AreEqual(expected.Destination, result.Destination);
                Assert.AreEqual(expected.Distance, result.Distance);
                Assert.AreEqual(expected.TravelCosts, result.TravelCosts);
            }
        }

        [TestMethod]
        public async Task UpdateJourneyShould_Throw_Null()
        {
            var nameOfDb = Guid.NewGuid().ToString();

            using(var  arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new JourneyService(assertContext);
                _ = await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await sut.UpdateJourneyAsync(1234, new JourneyInputDTO()));
            }
        }
    }
}
