using Agency.Services.DTOs.OutputDTOs;

namespace Agency.Services.Mappers
{
    public static class JourneyMapper
    {
        public static JourneyOutputDTO ToDTO(this Data.Models.Journey journey)
        {
            var j = new JourneyOutputDTO
            {
                Id = journey.Id,
                Name = "Journey " + journey.Id,
                StartLocation = journey.StartLocation,
                Destination = journey.Destination,
                Distance = journey.Distance,
                TravelCosts = journey.TravelCosts,
                Img = "https://w7.pngwing.com/pngs/216/962/png-transparent-location-icons-computer-icons-customer-experience-touchpoint-journey-text-service-people.png"
            };

            return j;
        }
    }
}
