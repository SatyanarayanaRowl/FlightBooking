using BookingManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagement.Repository
{
    public interface IBookingRepository
    {
        public IEnumerable<BookflightTbl> GetBookingDetail();
        public string AddBookingDetail(BookflightTblUsr bookflight);
        public IEnumerable<TicketDetail> GetUserHistory(string emailId);
        public IEnumerable<TicketDetail> GetBookingDetailFromPNR(string pnr);
        public void CancelBooking(string pnr);
    }
}
