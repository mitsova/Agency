using Agency.Data.Models;
using Agency.Services.Contracts;
using Agency.Services.DTOs.OutputDTOs;
using Agency.Services.Mappers;
using Agency.Web.Fetching_models;
using Microsoft.EntityFrameworkCore;

namespace Agency.Services.Services
{
    public class AirplaneService : IAirplaneService
    {
        private readonly AgencyContext _context;

        public AirplaneService(AgencyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AirplaneOutputDTO>> GetAllAirplanesAsync()
        {
            var planes = _context.Airplanes
                .Include(x => x.Vehicle)
                .ToList();

            var dtos = planes.Select(x => x.ToDTO());

            return dtos;
        }

        public async Task<bool> DeleteAirplaneAsync(int id)
        {
            var toDelete = _context.Airplanes
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (toDelete != null)
            {
                _context.Airplanes.Remove(toDelete);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task UpdateAirplaneAsync(int id, AirplaneInputDTO data)
        {
            var toUpdate = _context.Airplanes
                .Include(x => x.Vehicle)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (toUpdate != null)
            {
                toUpdate.Vehicle.PricePerKilometer = data.PricePerKilometer;
                toUpdate.Vehicle.PassangerCapacity = data.PassangerCapacity;
                toUpdate.HasFreeFood = data.HasFreeFood;
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task CreateAirplaneAsync(AirplaneInputDTO data)
        {
            var vehicle = new Vehicle
            {
                PassangerCapacity = data.PassangerCapacity,
                PricePerKilometer = data.PricePerKilometer,
                CategoryId = 1,
                TypeId = 1
            };

            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();

            var veh = _context.Vehicles.OrderBy(x => x.Id).Last();
            var plane = new Airplane
            {
                VehicleId = veh.Id,
                HasFreeFood = data.HasFreeFood
            };

            _context.Airplanes.Add(plane);
            _context.SaveChanges();
        }
    }
}
