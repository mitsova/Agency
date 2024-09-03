using Agency.Services.DTOs.OutputDTOs;
using Agency.Web.Fetching_models;

namespace Agency.Services.Contracts
{
    public interface ITrainService
    {
        Task<bool> DeleteTrainAsync(int id);
        Task<IEnumerable<TrainOutputDTO>> GetAllTrainsAsync();
        Task UpdateTrainAsync(int id, TrainInputDTO data);

        Task CreateTrainAsync(TrainInputDTO data);
    }
}