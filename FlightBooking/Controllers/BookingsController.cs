using FlightBooking.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBooking.Models;
using FlightBooking.Repository;

namespace FlightBooking.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BookingsController : Controller
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingsController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        
        //Get all bookings
        [HttpGet]
        public async Task<IActionResult> GetAllTicktes()
        {
            List<Bookings> bookings = await _bookingRepository.GetAllTickets();
            if (bookings != null)
            {
                return Ok(bookings);
            }

            return NotFound("No Booking tickets");
        }

        
        //Get Single Ticket 
        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetTicket")]
        public async Task<IActionResult> GetTicket([FromRoute] int id)
        {
            Bookings booking = await _bookingRepository.GetSingleTicket(id);
            if (booking != null)
            {
                return Ok(booking);
            }

            return NotFound("No Booking tickets");
        }

       
        //Save Ticket
        [HttpPost]
        public async Task<IActionResult> AddTicket([FromBody] Bookings bookingTicket)
        {
            await _bookingRepository.InsertTicktet(bookingTicket);

            return Ok("Record Inserted Successfully");
        }

       
        //update Ticket
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> CancelTicket([FromRoute] int id, [FromBody] Bookings bookingTicket)
        {
            Bookings booking = await _bookingRepository.CancelFlightTicket(id, bookingTicket);
            if (booking != null)
            {
                return Ok(booking);
            }

            return NotFound("No Booking tickets");
        }
        
    }
}
