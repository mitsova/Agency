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
    public class CreateJourneyShould
    {
        [TestMethod]
        public async Task CreateJournneyShould_Succeed()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var expected = new JourneyInputDTO
            {
                StartLocation = "Burgas",
                Destination = "Varna",
                Distance = 100,
                TravelCosts = 132.22m,
                VehicleId = 1
            };

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using(var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut  = new JourneyService(assertContext);
                await sut.CreateJourneyAsync(expected);

                var result = assertContext.Journeys.OrderBy(x => x.Id).Last();
                Assert.AreEqual(expected.StartLocation, result.StartLocation);
                Assert.AreEqual(expected.Destination, result.Destination);
                Assert.AreEqual(expected.Distance, result.Distance);
                Assert.AreEqual(expected.TravelCosts, result.TravelCosts);
                Assert.AreEqual(expected.VehicleId, result.VehicleId);
            }
        }
    }
}
