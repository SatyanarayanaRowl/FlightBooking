using BookingManagement.DBContext;
using BookingManagement.Models;
using BookingManagement.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagement.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingController(IBookingRepository bookingRepository)
        {
            this._bookingRepository = bookingRepository;
        }

        /// <summary>
        /// Get all Booking Details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllBooking")]
        [ActionName("GetAllBooking")]
        public IActionResult GetAllBooking()
        {
           // Response response = new Response();
            try
            {
                var allBookings = _bookingRepository.GetBookingDetail();
                if (allBookings != null)
                    return new OkObjectResult(allBookings);
                else
                    throw new Exception("No record found");
            }
            catch (Exception ex)
            {
            }
            return NotFound("");

        }

        //Add Booking for user
        [HttpPost]
        //[Route("add")]
        [ActionName("Post")]
        public  IActionResult Post([FromBody] BookflightTblUsr bookflight)
        {
            //Response response = new Response();
            try
            {
                {
                    string result =  _bookingRepository.AddBookingDetail(bookflight);
                  
                    return Ok();
                }
            }
            catch (Exception ex)
            {
            }
            return  NotFound("no data added");
        }

        [HttpGet]
        [Route("HistoryWithEmail")]
        [ActionName("HistoryWithEmail")]
        public IActionResult HistoryByEmail(string emailId)
        {
            try
            {
                var history = _bookingRepository.GetUserHistory(emailId);
                if (history != null)
                    return new OkObjectResult(history);
                else
                    throw new Exception("No history found");
            }
            catch (Exception ex)
            {
            }
            return NotFound();
        }

        [HttpDelete]
        public ActionResult CancelTicket(string pnr)
        {
            try
            {
               // var res = _bookingRepository.GetBookingDetailFromPNR(pnr);
                _bookingRepository.CancelBooking(pnr);
                return Ok();

            }
            catch (Exception ex)
            {
                
            }
            return  NotFound();
        }



        /// <summary>
        /// Get Ticket detail based upon pnr
        /// </summary>
        /// <param name="pnr"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("TicketDetailsByPNR")]
        [ActionName("TicketDetailsByPNR")]
        public IActionResult TicketDetailsByPNR(string pnr)
        {
            try
            {
                var result = _bookingRepository.GetBookingDetailFromPNR(pnr);
                if (result != null)
                {
                    return new OkObjectResult(result);
                }
                else
                    throw new Exception("Failed to get ticket based upon PNR " + pnr);
            }
            catch (Exception ex) {  }
            return NotFound();
        }
    }
}
