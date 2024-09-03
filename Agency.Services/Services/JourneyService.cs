using Agency.Data.Models;
using Agency.Services.Contracts;
using Agency.Services.DTOs.OutputDTOs;
using Agency.Services.Mappers;
using Agency.Web.Fetching_models;

namespace Agency.Services.Services
{
    public class JourneyService : IJourneyService
    {
        private readonly AgencyContext _context;

        public JourneyService(AgencyContext context)
        {
            _context = context;
        }

        public async Task CreateJourneyAsync(JourneyInputDTO data)
        {
            if (_context.Journeys.Where(x => x.StartLocation == data.StartLocation && x.Destination == data.Destination).FirstOrDefault() == null)
            {
                var journey = new Journey();
                journey.StartLocation = data.StartLocation;
                journey.Destination = data.Destination;
                journey.Distance = data.Distance;
                journey.TravelCosts = data.TravelCosts;
                journey.VehicleId = data.VehicleId;
                journey.CategoryId = 2;

                _context.Journeys.Add(journey);
                _context.SaveChanges();
            }
        }

        public async Task<bool> DeleteJourneyAsync(int id)
        {
            var journey = _context.Journeys.Where(x => x.Id == id).FirstOrDefault();

            if (journey != null)
            {
                _context.Journeys.Remove(journey);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<JourneyOutputDTO>> GetAllJourneysAsync()
        {
            var journeys = _context.Journeys.ToArray();

            var jDTO = journeys.Select(x => x.ToDTO());

            return jDTO;
        }

        public async Task UpdateJourneyAsync(int id, JourneyInputDTO data)
        {
            var toUpdate = _context.Journeys.Where(x => x.Id == id).FirstOrDefault();

            if (toUpdate != null)
            {
                toUpdate.StartLocation = data.StartLocation;
                toUpdate.Destination = data.Destination;
                toUpdate.Distance = data.Distance;
                toUpdate.TravelCosts = data.TravelCosts;

                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
