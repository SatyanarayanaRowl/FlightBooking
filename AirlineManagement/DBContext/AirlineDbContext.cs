using AirlineManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineManagement.DBContext
{
    public class AirlineDbContext:DbContext
    {
        public AirlineDbContext(DbContextOptions<AirlineDbContext> options) : base(options)
        {

        }


        public DbSet<Airline> Airlines { get; set; }
        public DbSet<InventoryTbl> inventoryTbls { get; set; }
    }
}
