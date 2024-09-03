using Agency.Services.DTOs.OutputDTOs;
using Agency.Web.Fetching_models;

namespace Agency.Services.Contracts
{
    public interface IBusService
    {
        Task<bool> DeleteBusAsync(int id);
        Task<IEnumerable<BusOutputDTO>> GetAllBusesAsync();
        Task UpdateBusAsync(int id, BusInputDTO data);

        Task CreateBusAsync(BusInputDTO data);
    }
}