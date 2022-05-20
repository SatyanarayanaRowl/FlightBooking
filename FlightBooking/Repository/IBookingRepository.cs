using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBooking.Models;

namespace FlightBooking.Repository
{
    public interface IBookingRepository
    {
        Task InsertTicktet(Bookings bookingTicket);
        Task<List<Bookings>> GetAllTickets();
        Task<Bookings> GetSingleTicket(int id);

        Task<Bookings> CancelFlightTicket(int id, Bookings bookingTicket);
    }
}
