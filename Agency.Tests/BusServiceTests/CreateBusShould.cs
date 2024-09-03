using Agency.Data.Models;
using Agency.Services.Services;
using Agency.Web.Fetching_models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.BusServiceTests
{
    [TestClass]
    public class CreateBusShould
    {
        [TestMethod]
        public async Task CreateBusShould_Succeed()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var expected = new BusInputDTO
            {
                PassangerCapacity = 15,
                PricePerKilometer = 7.33m
            };

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new BusService(assertContext);
                await sut.CreateBusAsync(expected);

                var result = assertContext.Buses.Include(x => x.Vehicle).OrderBy(x => x.Id).Last();
                Assert.AreEqual(expected.PricePerKilometer, result.Vehicle.PricePerKilometer);
                Assert.AreEqual(expected.PassangerCapacity, result.Vehicle.PassangerCapacity);
            }
        }
    }
}
