using Agency.Data.Models;
using Agency.Services.DTOs.OutputDTOs;
using Agency.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Tests.BusServiceTests
{
    [TestClass]
    public class GetAllBusesShould
    {
        [TestMethod]
        public async Task GetAllBusesShould_Succeed()
        {
            var nameOfDb = Guid.NewGuid().ToString();
            var expected = new[]
            {
                new BusOutputDTO { Id = 1, Name = "Bus 1", PassangerCapacity = 33, PricePerKilometer = 3, Img = "https://png.pngtree.com/png-vector/20220610/ourmid/pngtree-blue-bus-vektor-png-image_4938752.png" },
                new BusOutputDTO { Id = 2, Name = "Bus 2", PassangerCapacity = 22, PricePerKilometer = 2, Img = "https://png.pngtree.com/png-vector/20220610/ourmid/pngtree-blue-bus-vektor-png-image_4938752.png" }
            };

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new BusService(assertContext);
                var result = (await sut.GetAllBusesAsync()).ToArray();

                Assert.AreEqual(expected.Length, result.Length);

                for (int i = 0; i < expected.Length; i++)
                {
                    Assert.AreEqual(expected[i].Id, result[i].Id);
                    Assert.AreEqual(expected[i].Name, result[i].Name);
                    Assert.AreEqual(expected[i].PassangerCapacity, result[i].PassangerCapacity);
                    Assert.AreEqual(expected[i].PricePerKilometer, result[i].PricePerKilometer);
                    Assert.AreEqual(expected[i].Img, result[i].Img);
                }
            }
        }
    }
}
