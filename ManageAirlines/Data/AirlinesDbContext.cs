using ManageAirlines.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageAirlines.Data
{
    public class AirlinesDbContext : DbContext
    {
        public AirlinesDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Airlines> ManageFlights { get; set; }
    }
}
