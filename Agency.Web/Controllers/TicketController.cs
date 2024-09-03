using Agency.Data;
using Agency.Data.Models;
using Agency.Services.Contracts;
using Agency.Services.Services;
using Agency.Web.Fetching_models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Agency.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        [Route("Tickets")]
        public async Task<IActionResult> GetAllTickets()
        {
            try
            {
                var tickets = await _ticketService.GetAllTicketsAsync();


                if (tickets != null && tickets.Count() > 0)
                {
                    return Ok(tickets);
                }

                return Ok("there are no tickets");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Tickets/{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            try
            {
                var isDeleted = await _ticketService.DeleteTicketAsync(id);

                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Tickets/{id}")]
        public async Task<IActionResult> UpdateTicket(int id, [FromBody] TicketInputDTO data)
        {
            try
            {
                await _ticketService.UpdateTicketAsync(id, data);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] TicketInputDTO data)
        {
            try
            {
                await _ticketService.CreateTicketAsync(data);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}