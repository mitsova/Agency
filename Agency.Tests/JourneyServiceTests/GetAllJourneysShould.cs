using Agency.Data.Models;
using Agency.Services.DTOs.OutputDTOs;
using Agency.Services.Services;

namespace Agency.Tests.JourneyServiceTests
{
    [TestClass]
    public class GetAllJourneysShould
    {
        [TestMethod]
        public async Task GetAllJourneysShould_Succeed()
        {
            var nameOfDb = Guid.NewGuid().ToString();

            var expected = new[]
            {
                new JourneyOutputDTO {
                    Id = 1,
                    Name = "Journey 1",
                    StartLocation = "Ruse",
                    Destination = "Sofia",
                    TravelCosts = 432.11m,
                    Distance = 320.15,
                    Img  = "https://w7.pngwing.com/pngs/216/962/png-transparent-location-icons-computer-icons-customer-experience-touchpoint-journey-text-service-people.png"},
                new JourneyOutputDTO  {
                    Id = 2,
                    Name = "Journey 2",
                    StartLocation = "Sofia",
                    Destination= "London",
                    Distance = 1450,
                    TravelCosts= 1234.56m,
                    Img  = "https://w7.pngwing.com/pngs/216/962/png-transparent-location-icons-computer-icons-customer-experience-touchpoint-journey-text-service-people.png"},
                new JourneyOutputDTO  {
                    Id = 3,
                    Name = "Journey 3",
                    StartLocation = "Ruse", 
                    Destination = "Varna", 
                    TravelCosts = 230, 
                    Distance = 187.3, 
                    Img  = "https://w7.pngwing.com/pngs/216/962/png-transparent-location-icons-computer-icons-customer-experience-touchpoint-journey-text-service-people.png"}
            };

            using (var arrangeContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                Utils.Seed(arrangeContext);
            }

            using (var assertContext = new AgencyContext(Utils.GetOptions(nameOfDb)))
            {
                var sut = new JourneyService(assertContext);
                var result = (await sut.GetAllJourneysAsync()).ToArray();

                Assert.AreEqual(expected.Length, result.Length);

                for (int i = 0; i < result.Length; i++)
                {
                    Assert.AreEqual(expected[i].Id, result[i].Id);
                    Assert.AreEqual(expected[i].Name, result[i].Name);
                    Assert.AreEqual(expected[i].Destination, result[i].Destination);
                    Assert.AreEqual(expected[i].StartLocation, result[i].StartLocation);
                    Assert.AreEqual(expected[i].Distance, result[i].Distance);
                    Assert.AreEqual(expected[i].Img, result[i].Img);
                    Assert.AreEqual(expected[i].TravelCosts, result[i].TravelCosts);
                }
            }
        }
    }
}
