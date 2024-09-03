using Agency.Data.Models;
using Agency.Services.DTOs.OutputDTOs;
using Agency.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.TrainServiceTests
{
    [TestClass]
    public class GetAllTrainsShould
    {
        [TestMethod]
        public async Task GetAllTrainsShould_Succeed()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var expected = new[]
            {
                new TrainOutputDTO { Id = 1, Name = "Train 1", PassangerCapacity = 69, PricePerKilometer = 2.41m, CartsAmount = 6, Img = "https://w7.pngwing.com/pngs/202/183/png-transparent-train-rail-transport-train-mode-of-transport-railroad-car-vehicle-thumbnail.png"},
                new TrainOutputDTO { Id = 2, Name = "Train 2", PassangerCapacity = 80, PricePerKilometer = 2.41m, CartsAmount = 8, Img = "https://w7.pngwing.com/pngs/202/183/png-transparent-train-rail-transport-train-mode-of-transport-railroad-car-vehicle-thumbnail.png"}
            };

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new TrainService(assertContext);
                var result = (await sut.GetAllTrainsAsync()).ToArray();

                Assert.AreEqual(expected.Length, result.Length);
                for (int i = 0; i < expected.Length; i++)
                {
                    Assert.AreEqual(expected[i].Id, result[i].Id);
                    Assert.AreEqual(expected[i].Img, result[i].Img);
                    Assert.AreEqual(expected[i].Name, result[i].Name);
                    Assert.AreEqual(expected[i].PassangerCapacity, result[i].PassangerCapacity);
                    Assert.AreEqual(expected[i].PricePerKilometer, result[i].PricePerKilometer);
                    Assert.AreEqual(expected[i].CartsAmount, result[i].CartsAmount);
                }
            }
        }
    }
}
