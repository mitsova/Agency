using Agency.Data.Models;
using Agency.Services.Contracts;
using Agency.Web.Fetching_models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Agency.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private readonly IJourneyService _journeyService;

        public JourneyController(IJourneyService service)
        {
            _journeyService = service;
        }

        [HttpGet]
        [Route("Journeys")]
        public async Task<IActionResult> GetAllJourneys()
        {
            try
            {
                var journeys = await _journeyService.GetAllJourneysAsync();

                if (journeys != null && journeys.Count() > 0)
                {
                    return Ok(journeys);
                }

                return Ok("There are no journeys registered");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Journeys/{id}")]
        public async Task<IActionResult> DeleteJourney(int id)
        {
            try
            {
                var isDeleted = await _journeyService.DeleteJourneyAsync(id);

                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Journeys/{id}")]
        public async Task<IActionResult> UpdateJourney(int id, [FromBody] JourneyInputDTO data)
        {
            try
            {
                await _journeyService.UpdateJourneyAsync(id, data);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateJourney([FromBody] JourneyInputDTO data)
        {
            try
            {
                await _journeyService.CreateJourneyAsync(data);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
