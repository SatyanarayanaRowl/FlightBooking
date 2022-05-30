using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineManagement.Models
{
    public class Airline
    {
        [Key]
        public string AirlineNo { get; set; }
        public string UploadLogo { get; set; }
        public string ContactNumber { get; set; }
        public string ContactAddress { get; set; }
    }
}
