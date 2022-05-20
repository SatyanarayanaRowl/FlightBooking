using ManageAirlines.Data;
using ManageAirlines.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageAirlines.Repository;

namespace ManageAirlines.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class AirlinesController : Controller
    {
        private readonly IAirlineRepository _airlineRepository;

        public AirlinesController(IAirlineRepository airlineRepository)
        {
            this._airlineRepository = airlineRepository;
        }

        //Get All Flights
        [HttpGet]
        public async Task<IActionResult> GetAllFlights()
        {
            List<Airlines> airines = await _airlineRepository.GetAllFlights();
            if (airines != null)
            {
                return Ok(airines);
            }
            return NotFound("No Booking tickets");
        }      

        //Get Single Flight 
        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetFlight")]
        public async Task<IActionResult> GetFlight([FromRoute] int id)
        {
            Airlines airine = await _airlineRepository.GetFlight(id);
            if (airine != null)
            {
                return Ok(airine);
            }

            return NotFound("No Booking tickets");
        }     

        //Add Airline
        [HttpPost]
        public async Task<IActionResult> AddAirline([FromBody] Airlines airlines)
        {
            await _airlineRepository.InsertAirline(airlines);
            return Ok("Record Inserted Successfully");

            //return CreatedAtAction(nameof(GetFlight), airlines.FlightId, airlines);
        }
    
        //Blocking Airlines
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> BlockingAirline([FromRoute] int id, [FromBody] Airlines airlines)
        {
            var existAirline= await _airlineRepository.CancelAirline(id, airlines);
            if (existAirline != null)
            {
                return Ok(existAirline);

            }
                return NotFound("Ticket not Found");
        }

    
    }
}
