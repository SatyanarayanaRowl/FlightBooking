using AirlineManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineManagement.DBContext;
using Microsoft.EntityFrameworkCore;

namespace AirlineManagement.Repository
{
    public class AirlineRepository : IAirlineRepository
    {
        private readonly AirlineDbContext airlinesDbContext;

        public AirlineRepository(AirlineDbContext airlinesDbContext)
        {
            this.airlinesDbContext = airlinesDbContext;
        }
       
        public async Task<List<Airline>> GetAirlines()
        {
            return await airlinesDbContext.Airlines.ToListAsync();
        }

        public async Task InsertAirline(Airline airline)
        {
            await airlinesDbContext.Airlines.AddAsync(airline);
            await airlinesDbContext.SaveChangesAsync();
        }

        public async Task CancelAirline(string airlineNo)
        {
            var airline = await airlinesDbContext.Airlines.FindAsync(airlineNo);
            airlinesDbContext.Airlines.Remove(airline);
            await airlinesDbContext.SaveChangesAsync();
        }

    }
}
