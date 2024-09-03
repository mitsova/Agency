using Agency.Services.DTOs.OutputDTOs;

namespace Agency.Services.Mappers
{
    public static class BusMapper
    {
        public static BusOutputDTO ToDTO(this Data.Models.Bus bus)
        {
            var b = new BusOutputDTO
            {
                Id = bus.Id,
                Name = $"Bus {bus.Id}",
                PassangerCapacity = bus.Vehicle.PassangerCapacity,
                PricePerKilometer = bus.Vehicle.PricePerKilometer,
                Img = "https://png.pngtree.com/png-vector/20220610/ourmid/pngtree-blue-bus-vektor-png-image_4938752.png"
            };

            return b;
        }
    }
}
