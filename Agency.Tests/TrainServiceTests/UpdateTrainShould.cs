using Agency.Data.Models;
using Agency.Services.Services;
using Agency.Web.Fetching_models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.TrainServiceTests
{
    [TestClass]
    public class UpdateTrainShould
    {
        [TestMethod]
        public async Task UpdateTrainShould_Succeed()
        {
            var  nameOfDb = Guid.NewGuid().ToString();
            var idToUpdate = 1;
            var expected = new TrainInputDTO
            {
                PassangerCapacity = 123,
                PricePerKilometer = 1.23m,
                CartsAmount = 2
            };

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext =  new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new TrainService(assertContext);
                await sut.UpdateTrainAsync(idToUpdate, expected);

                var result = assertContext.Trains.Include(x => x.Vehicle).Where(x => x.Id == idToUpdate).First();

                Assert.AreEqual(expected.PricePerKilometer, result.Vehicle.PricePerKilometer);
                Assert.AreEqual(expected.PassangerCapacity, result.Vehicle.PassangerCapacity);
                Assert.AreEqual(expected.CartsAmount, result.CartsAmount);
            }
        }

        [TestMethod]
        public async Task UpdateTrainShould_Throw_Null()
        {
            var nameOfDb = Guid.NewGuid().ToString();

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using(var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new TrainService(assertContext);

                _ = await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await sut.UpdateTrainAsync(12345, new TrainInputDTO()));
            }
        }
    }
}
