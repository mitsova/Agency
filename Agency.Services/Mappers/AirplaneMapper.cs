using Agency.Services.DTOs.OutputDTOs;

namespace Agency.Services.Mappers
{
    public static class AirplaneMapper
    {
        public static AirplaneOutputDTO ToDTO(this Data.Models.Airplane airplane)
        {
            var a = new AirplaneOutputDTO
            {
                Id = airplane.Id,
                Name = $"Airplane {airplane.Id}",
                PassangerCapacity = airplane.Vehicle.PassangerCapacity,
                PricePerKilometer = airplane.Vehicle.PricePerKilometer,
                HasFreeFood = airplane.HasFreeFood,
                Img = "https://w7.pngwing.com/pngs/594/444/png-transparent-airplane-animated-cartoon-airplane-flight-transport-vehicle.png"
            };

            return a;
        }
    }
}
