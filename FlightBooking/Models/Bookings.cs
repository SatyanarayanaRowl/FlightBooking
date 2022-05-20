using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Models
{
    public class Bookings
    {
        [Key]
        public int PnrID { get; set; }
        public string EmailID { get; set; }
        public int PassengerID { get; set; }
        public string PassengerName { get; set; }
        public string PassengerAge { get; set; }
        public int NumberOfSeats { get; set; }
        public string MealsOption { get; set; }
        public string SelectedSeatNumbers { get; set; }
        public DateTime BookingTime { get; set; }
        public bool IsActive { get; set; }
       
        
    }
}
