using Agency.Services.DTOs.OutputDTOs;
using Agency.Web.Fetching_models;

namespace Agency.Services.Contracts
{
    public interface IAirplaneService
    {
        Task<bool> DeleteAirplaneAsync(int id);
        Task<IEnumerable<AirplaneOutputDTO>> GetAllAirplanesAsync();
        Task UpdateAirplaneAsync(int id, AirplaneInputDTO data);

        Task CreateAirplaneAsync(AirplaneInputDTO data);
    }
}