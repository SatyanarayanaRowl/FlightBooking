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
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _inventoryRepository;
        public InventoryController(IInventoryRepository repository)
        {
            _inventoryRepository = repository;
        }

        [HttpGet]
        [ActionName("GetInventory")]
        public IActionResult GetInventory()
        {
        
            try
            {
                var airline = _inventoryRepository.GetInventory();
                if (airline == null)
                    throw new Exception("No flight exists");
                else
                    return new OkObjectResult(airline);
            }
            catch (Exception ex)
            {
                
            }
            return NotFound("No Inventory data");
        }


        /// <summary>
        /// Add Inventory for airlines
        /// </summary>
        /// <param name="tbl"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddInventory")]
        public IActionResult AddInventory([FromBody] InventoryTbl tbl)
        {
           
            try
            {
                _inventoryRepository.AddInventory(tbl);
                return Ok();
            }
            catch (Exception ex)
            {
               
            }
            return  NotFound();
        }

        
    }
}
