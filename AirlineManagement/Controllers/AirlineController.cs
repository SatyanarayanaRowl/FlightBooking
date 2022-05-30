using AirlineManagement.Models;
using AirlineManagement.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AirlineController : ControllerBase
    {
        private readonly IAirlineRepository _airlineRepository;

        public AirlineController(IAirlineRepository airlineRepository)
        {
            this._airlineRepository = airlineRepository;
        }

        //Get All Airlines
        [HttpGet]
        [ActionName("GetAllAirlines")]
        //[AllowAnonymous]
        public async Task<IActionResult> GetAllAirlines()
        {
            try
            {
                List<Airline> airines = await _airlineRepository.GetAirlines();
                if (airines != null)
                {
                    return Ok(airines);
                }
            }
            catch (Exception ex)
            {
            }
   
            return NotFound("No Airline Data");
        }       

        //Add Airline
        [HttpPost]
        [ActionName("AddAirline")]       
        public async Task<IActionResult> AddAirline([FromBody] Airline airline)
        {
            try
            {
                await _airlineRepository.InsertAirline(airline);
                //return Ok("Record Inserted Successfully");
                return Ok();
            }
            catch (Exception ex)
            {
            }
            return NotFound("Failed to register airlines");
            //return CreatedAtAction(nameof(GetFlight), airlines.FlightId, airlines);
        }

        //Blocking Airline
        [HttpDelete]
        public async Task<IActionResult> BlockingAirline(string airlineNo)
        {
            try
            {
                await _airlineRepository.CancelAirline(airlineNo);
                //return Ok("Record Delete Successfully");
                return Ok();
            }
            catch(Exception ex)
            {

            }
            return NotFound("Failed to block airlines");
        }

    }
}
