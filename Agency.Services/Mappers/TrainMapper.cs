using Agency.Services.DTOs.OutputDTOs;

namespace Agency.Services.Mappers
{
    public static class TrainMapper
    {
        public static TrainOutputDTO ToDTO(this Data.Models.Train train)
        {
            var t = new TrainOutputDTO
            {
                Id = train.Id,
                Name = $"Train {train.Id}",
                PassangerCapacity = train.Vehicle.PassangerCapacity,
                PricePerKilometer = train.Vehicle.PricePerKilometer,
                CartsAmount = train.CartsAmount,
                Img = "https://w7.pngwing.com/pngs/202/183/png-transparent-train-rail-transport-train-mode-of-transport-railroad-car-vehicle-thumbnail.png"
            };

            return t;
        }
    }
}
