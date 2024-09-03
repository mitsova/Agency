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
    public class TicketService : ITicketService
    {
        private readonly AgencyContext _context;

        public TicketService(AgencyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TicketOutputDTO>> GetAllTicketsAsync()
        {
            var tickets = _context.Tickets.Include(x => x.Journey).ToList();

            var ticketDtos = tickets.Select(x => x.ToDTO()).ToList();

            return ticketDtos;
        }

        public async Task<bool> DeleteTicketAsync(int id)
        {
            var ticket = _context.Tickets.Where(x => x.Id == id).FirstOrDefault();

            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task UpdateTicketAsync(int id, TicketInputDTO data)
        {
            var toUpdate = _context.Tickets.Where(x => x.Id == id).FirstOrDefault();
            if (toUpdate != null)
            {
                toUpdate.Price = data.Price;
                toUpdate.AdministrativeCosts = data.AdministrativeCosts;
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task CreateTicketAsync(TicketInputDTO data)
        {
            var ticket = new Ticket();
            ticket.AdministrativeCosts = data.AdministrativeCosts;
            ticket.Price = data.Price;
            ticket.JourneyId = data.JourneyId;
            ticket.CategoryId = 3;

            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }
    }
}
