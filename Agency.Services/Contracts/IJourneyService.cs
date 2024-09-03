using Agency.Services.DTOs.OutputDTOs;
using Agency.Web.Fetching_models;

namespace Agency.Services.Contracts
{
    public interface IJourneyService
    {
        Task CreateJourneyAsync(JourneyInputDTO data);

        Task<bool> DeleteJourneyAsync(int id);

        Task<IEnumerable<JourneyOutputDTO>> GetAllJourneysAsync();

        Task UpdateJourneyAsync(int id, JourneyInputDTO data);
    }
}