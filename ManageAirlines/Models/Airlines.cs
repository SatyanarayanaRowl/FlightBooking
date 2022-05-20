using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManageAirlines.Models
{
    public class Airlines
    {
        [Key]
        public int FlightId { get; set; }
        public string Airline { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ScehduledDates { get; set; }
        public string Instrument { get; set; }
        public int BusinessSeats { get; set; }
        public int NonBusinessSeats { get; set; }
        public decimal TciketCost { get; set; }
        public int NoOfRows { get; set; }
        public string Meals { get; set; }
        public bool IsActive { get; set; }

    }
}
