using Agency.Data.Models;
using Agency.Services.Services;
using Agency.Web.Fetching_models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.AirplaneServiceTests
{
    [TestClass]
    public class CreateAirplaneShould
    {
        [TestMethod]
        public async Task CreateAirplaneShould_Succeed()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var expected = new AirplaneInputDTO
            {
                PassangerCapacity = 222,
                PricePerKilometer = 11.34m,
                HasFreeFood = true,
            };

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new AirplaneService(assertContext);
                await sut.CreateAirplaneAsync(expected);

                var result = assertContext.Airplanes.Include(x => x.Vehicle).OrderBy(x => x.Id).Last();
                Assert.AreEqual(expected.PricePerKilometer, result.Vehicle.PricePerKilometer);
                Assert.AreEqual(expected.PassangerCapacity, result.Vehicle.PassangerCapacity);
                Assert.AreEqual(expected.HasFreeFood, result.HasFreeFood);
            }
        }
    }
}
