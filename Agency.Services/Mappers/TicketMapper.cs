using Agency.Services.DTOs.OutputDTOs;

namespace Agency.Services.Mappers
{
    public static class TicketMapper
    {
        public static TicketOutputDTO ToDTO(this Data.Models.Ticket ticket)
        {
            var tick = new TicketOutputDTO
            {
                Id = ticket.Id,
                Name = $"Ticket " + ticket.Id,
                Destination = ticket.Journey.Destination,
                Price = ticket.Price,
                AdministrativeCosts = ticket.AdministrativeCosts,
                Img = "https://e7.pngegg.com/pngimages/706/889/png-clipart-ticket-ticket-miscellaneous-template.png"
            };

            return tick;
        }
    }
}
