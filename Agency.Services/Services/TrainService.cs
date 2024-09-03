using Agency.Data.Models;
using Agency.Services.Contracts;
using Agency.Services.DTOs.OutputDTOs;
using Agency.Services.Mappers;
using Agency.Web.Fetching_models;
using Microsoft.EntityFrameworkCore;

namespace Agency.Services.Services
{
    public class TrainService : ITrainService
    {
        private readonly AgencyContext _context;

        public TrainService(AgencyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TrainOutputDTO>> GetAllTrainsAsync()
        {
            var trains = _context.Trains
                .Include(x => x.Vehicle)
                .ToList();

            var dtos = trains.Select(x => x.ToDTO());

            return dtos;
        }

        public async Task<bool> DeleteTrainAsync(int id)
        {
            var toDelete = _context.Trains
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (toDelete != null)
            {
                _context.Trains.Remove(toDelete);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task UpdateTrainAsync(int id, TrainInputDTO data)
        {
            var toUpdate = _context.Trains
                .Include(x => x.Vehicle)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (toUpdate != null)
            {
                toUpdate.Vehicle.PricePerKilometer = data.PricePerKilometer;
                toUpdate.Vehicle.PassangerCapacity = data.PassangerCapacity;
                toUpdate.CartsAmount = data.CartsAmount;
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task CreateTrainAsync(TrainInputDTO data)
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
            var train = new Train
            {
                VehicleId = veh.Id,
                CartsAmount = data.CartsAmount
            };

            _context.Trains.Add(train);
            _context.SaveChanges();
        }
    }
}
