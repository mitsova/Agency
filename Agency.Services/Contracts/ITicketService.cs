using Agency.Services.DTOs.OutputDTOs;
using Agency.Web.Fetching_models;

namespace Agency.Services.Contracts
{
    public interface ITicketService
    {
        Task CreateTicketAsync(TicketInputDTO data);

        Task<bool> DeleteTicketAsync(int id);

        Task<IEnumerable<TicketOutputDTO>> GetAllTicketsAsync();

        Task UpdateTicketAsync(int id, TicketInputDTO data);
    }
}