using FlightBooking.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBooking.Models;

namespace FlightBooking.Repository
{
    public class BookingRepository: IBookingRepository
    {
        private readonly BookingsDbContext bookingsDbContext;

        public BookingRepository(BookingsDbContext bookingsDbContext)
        {
            this.bookingsDbContext = bookingsDbContext;
        }

        
        public  async Task<List<Bookings>> GetAllTickets()
        {
            return await bookingsDbContext.BookingTickets.ToListAsync();
        }

        public async Task<Bookings> GetSingleTicket(int id)
        {
            return await bookingsDbContext.BookingTickets.FirstOrDefaultAsync(x => x.PnrID == id);
        }

        public async Task InsertTicktet(Bookings bookingTicket)
        {
            await bookingsDbContext.BookingTickets.AddAsync(bookingTicket);
            await bookingsDbContext.SaveChangesAsync();
        }

        public async Task<Bookings> CancelFlightTicket(int id, Bookings bookingTicket)
        {
            var existBooking = await bookingsDbContext.BookingTickets.FirstOrDefaultAsync(x => x.PnrID == id);
            if (existBooking != null)
            {
                existBooking.IsActive = bookingTicket.IsActive;
                await bookingsDbContext.SaveChangesAsync();
                return existBooking;
            }
            return existBooking;
        }
    }
}
