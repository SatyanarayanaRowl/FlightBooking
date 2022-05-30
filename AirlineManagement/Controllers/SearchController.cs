using AirlineManagement.Repository;
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
    public class SearchController : ControllerBase
    {
        private readonly IInventoryRepository _inventoryRepository;
        public SearchController(IInventoryRepository repository)
        {
            _inventoryRepository = repository;
        }

        [HttpGet]
        [ActionName("GetAllFlightBasedUponPlaces")]
        public IActionResult GetAllFlightBasedUponPlaces(string fromplace, string toplace)
        {
            //Response response = new Response();
            try
            {
                var flights = _inventoryRepository.GetAllFlightBasedUponPlaces(fromplace, toplace);
                if (flights.Count() != 0)
                    return new OkObjectResult(flights);
                else
                    throw new Exception("No flight exists");
            }
            catch (Exception ex)
            {

            }
            return NotFound();
        }
    }
}
