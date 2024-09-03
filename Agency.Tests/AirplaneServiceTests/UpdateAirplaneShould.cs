using Agency.Data.Models;
using Agency.Services.Services;
using Agency.Web.Fetching_models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.AirplaneServiceTests
{
    [TestClass]
    public class UpdateAirplaneShould
    {
        [TestMethod]
        public async Task UpdateAirplaneShould_Succeed()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var idToUpdate = 1;
            var expected = new AirplaneInputDTO
            {
                PassangerCapacity = 12345,
                PricePerKilometer = 12.34m,
                HasFreeFood = false
            };

            using(var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new AirplaneService(assertContext);
                await sut.UpdateAirplaneAsync(idToUpdate, expected);

                var result = assertContext.Airplanes.Include(x => x.Vehicle).Where(x => x.Id == idToUpdate).First();

                Assert.AreEqual(expected.PricePerKilometer, result.Vehicle.PricePerKilometer);
                Assert.AreEqual(expected.PassangerCapacity, result.Vehicle.PassangerCapacity);
                Assert.AreEqual(expected.HasFreeFood, result.HasFreeFood);
            }
        }

        [TestMethod]
        public async Task UpdateAirplaneShould_Throw_Null()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var invalidId = 0;

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new AirplaneService(assertContext);

                _ = await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await sut.UpdateAirplaneAsync(invalidId, new AirplaneInputDTO()));
            }
        }
    }
}
