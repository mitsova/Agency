using Agency.Data.Models;
using Agency.Services.Contracts;
using Agency.Web.Fetching_models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agency.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IBusService _busService;
        private readonly ITrainService _trainService;
        private readonly IAirplaneService _airplaneService;

        public VehicleController(ITrainService trainService, IBusService busService, IAirplaneService airplaneService)
        {
            _busService = busService;
            _trainService = trainService;
            _airplaneService = airplaneService;
        }

        [HttpGet]
        [Route("Trains")]
        public async Task<IActionResult> GetAllTrains()
        {
            try
            {
                var trains = await _trainService.GetAllTrainsAsync();

                if (trains != null && trains.Count() > 0)
                {
                    return Ok(trains);
                }

                return Ok("No trains Found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("Trains/{id}")]
        public async Task<IActionResult> DeleteTrain(int id)
        {
            try
            {
                var isDeleted = await _trainService.DeleteTrainAsync(id);

                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Trains/{id}")]
        public async Task<IActionResult> EditTrain(int id, [FromBody] TrainInputDTO data)
        {
            try
            {
                await _trainService.UpdateTrainAsync(id, data);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Trains")]
        public async Task<IActionResult> CreateTrain([FromBody] TrainInputDTO data)
        {
            try
            {
                await _trainService.CreateTrainAsync(data);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Buses")]
        public async Task<IActionResult> GetAllBuses()
        {
            try
            {
                var buses = await _busService.GetAllBusesAsync();

                if (buses != null && buses.Count() > 0)
                {
                    return Ok(buses);
                }

                return Ok("No buses Found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Buses")]
        public async Task<IActionResult> CreateBus([FromBody] BusInputDTO data)
        {
            try
            {
                await _busService.CreateBusAsync(data);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Buses/{id}")]
        public async Task<IActionResult> DeleteBus(int id)
        {
            try
            {
                var isDeleted = await _busService.DeleteBusAsync(id);

                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Buses/{id}")]
        public async Task<IActionResult> EditBus(int id, [FromBody] BusInputDTO data)
        {
            try
            {
                await _busService.UpdateBusAsync(id, data);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Airplanes")]
        public async Task<IActionResult> GetAllAirplanes()
        {
            try
            {
                var airplanes = await _airplaneService.GetAllAirplanesAsync();

                if (airplanes != null && airplanes.Count() > 0)
                {
                    return Ok(airplanes);
                }

                return Ok("No Airplanes Found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Airplanes")]
        public async Task<IActionResult> CreateAirplane([FromBody] AirplaneInputDTO data)
        {
            try
            {
                await _airplaneService.CreateAirplaneAsync(data);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Airplanes/{id}")]
        public async Task<IActionResult> DeleteAirplane(int id)
        {
            try
            {
                var isDeleted = await _airplaneService.DeleteAirplaneAsync(id);

                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Airplanes/{id}")]
        public async Task<IActionResult> EditAirplane(int id, [FromBody] AirplaneInputDTO data)
        {
            try
            {
                await _airplaneService.UpdateAirplaneAsync(id, data);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
