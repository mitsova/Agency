using Agency.Data.Models;
using Agency.Services.DTOs.OutputDTOs;
using Agency.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.AirplaneServiceTests
{
    [TestClass]
    public class GetAllAirplanesShould
    {
        [TestMethod]
        public async Task GetAllAirplanesShould_Succeed()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var expected = new []
            {
                new AirplaneOutputDTO { Id = 1, Name = "Airplane 1", PassangerCapacity = 167, PricePerKilometer = 5.76m, HasFreeFood = true , Img = "https://w7.pngwing.com/pngs/594/444/png-transparent-airplane-animated-cartoon-airplane-flight-transport-vehicle.png"},
                new AirplaneOutputDTO { Id = 2, Name = "Airplane 2", PassangerCapacity = 157, PricePerKilometer = 3.84m, HasFreeFood = false, Img = "https://w7.pngwing.com/pngs/594/444/png-transparent-airplane-animated-cartoon-airplane-flight-transport-vehicle.png" }
            };

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new AirplaneService(assertContext);

                var result = (await sut.GetAllAirplanesAsync()).ToArray();

                Assert.AreEqual(expected.Length, result.Length);
                for (int i = 0; i < expected.Length; i++)
                {
                    Assert.AreEqual(expected[i].Id, result[i].Id);
                    Assert.AreEqual(expected[i].Name, result[i].Name);
                    Assert.AreEqual(expected[i].PricePerKilometer, result[i].PricePerKilometer);
                    Assert.AreEqual(expected[i].PassangerCapacity, result[i].PassangerCapacity);
                    Assert.AreEqual(expected[i].HasFreeFood, result[i].HasFreeFood);
                }
            }
        }
    }
}
