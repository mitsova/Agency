using Agency.Data.Models;
using Agency.Services.Services;
using Agency.Web.Fetching_models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.TrainServiceTests
{
    [TestClass]
    public class CreateTrainShould
    {
        [TestMethod]
        public async Task CreateTrainShould_Succeed()
        {
            var nameOfdb = Guid.NewGuid().ToString();
            var expected = new TrainInputDTO
            {
                PassangerCapacity = 666,
                PricePerKilometer = 0.99m,
                CartsAmount = 6
            };

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfdb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfdb)))
            {
                var sut = new TrainService(assertContext);
                await sut.CreateTrainAsync(expected);

                var result = assertContext.Trains.Include(x => x.Vehicle).OrderBy(x => x.Id).Last();

                Assert.AreEqual(expected.PricePerKilometer, result.Vehicle.PricePerKilometer);
                Assert.AreEqual(expected.PassangerCapacity, result.Vehicle.PassangerCapacity);
                Assert.AreEqual(expected.CartsAmount, result.CartsAmount);
            }
        }
    }
}
