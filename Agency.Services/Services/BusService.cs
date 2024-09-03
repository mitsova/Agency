using Agency.Data.Models;
using Agency.Services.Contracts;
using Agency.Services.DTOs.OutputDTOs;
using Agency.Services.Mappers;
using Agency.Web.Fetching_models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Services.Services
{
    public class BusService : IBusService
    {
        private readonly AgencyContext _context;
        public BusService(AgencyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BusOutputDTO>> GetAllBusesAsync()
        {
            var buses = _context.Buses
                .Include(x => x.Vehicle)
                .ToList();

            var dtos = buses.Select(x => x.ToDTO());

            return dtos;
        }

        public async Task<bool> DeleteBusAsync(int id)
        {
            var toDelete = _context.Buses
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (toDelete != null)
            {
                _context.Buses.Remove(toDelete);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task UpdateBusAsync(int id, BusInputDTO data)
        {
            var toUpdate = _context.Buses
                .Include(x => x.Vehicle)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (toUpdate != null)
            {
                toUpdate.Vehicle.PricePerKilometer = data.PricePerKilometer;
                toUpdate.Vehicle.PassangerCapacity = data.PassangerCapacity;
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task CreateBusAsync(BusInputDTO data)
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
            var bus = new Bus
            {
                VehicleId = veh.Id
            };

            _context.Buses.Add(bus);
            _context.SaveChanges();
        }
    }
}
