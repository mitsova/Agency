using Agency.Data.Models;
using Agency.Services.Services;
using Agency.Web.Fetching_models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.BusServiceTests
{
    [TestClass]
    public class UpdateBusShould
    {
        [TestMethod]
        public async Task UpdateBusShould_Succeed()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var idToUpdate = 1;
            var expected = new BusInputDTO
            {
                PassangerCapacity = 1234,
                PricePerKilometer = 12.34m
            };

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut  = new BusService(assertContext);
                await sut.UpdateBusAsync(idToUpdate, expected);

                var result = assertContext.Buses.Include(x => x.Vehicle).Where(x =>  x.Id == idToUpdate).First();
                Assert.AreEqual(expected.PricePerKilometer, result.Vehicle.PricePerKilometer);
                Assert.AreEqual(expected.PassangerCapacity, result.Vehicle.PassangerCapacity);
            }
        }

        [TestMethod]
        public async Task UpdateBusShould_Throw_Null()
        {
            var nameOfDb = Guid.NewGuid().ToString();

            using(var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new BusService(assertContext);
                _ = await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await sut.UpdateBusAsync(123, new BusInputDTO()));
            }
        }
    }
}
