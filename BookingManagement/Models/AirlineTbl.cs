using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BookingManagement.Models
{
    public class AirlineTbl
    {
        [Key]
        public string AirlineNo { get; set; }
        public string UploadLogo { get; set; }
        public string ContactNumber { get; set; }
        public string ContactAddress { get; set; }
        public virtual ICollection<InventoryTbl> Inventories { get; set; }
    }
}
