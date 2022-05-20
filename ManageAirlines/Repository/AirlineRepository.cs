using ManageAirlines.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageAirlines.Models;

namespace ManageAirlines.Repository
{
    public class AirlineRepository : IAirlineRepository
    {
        private readonly AirlinesDbContext airlinesDbContext;

        public AirlineRepository(AirlinesDbContext airlinesDbContext)
        {
            this.airlinesDbContext = airlinesDbContext;
        }

        

        public async Task<List<Airlines>> GetAllFlights()
        {
            return await airlinesDbContext.ManageFlights.ToListAsync();
        }

        public async Task<Airlines> GetFlight(int id)
        {
            return await airlinesDbContext.ManageFlights.FirstOrDefaultAsync(x => x.FlightId == id);
        }

        public async Task InsertAirline(Airlines airlines)
        {
            await airlinesDbContext.ManageFlights.AddAsync(airlines);
            await airlinesDbContext.SaveChangesAsync();
        }

        public async Task<Airlines> CancelAirline(int id, Airlines airlines)
        {
            var existAirline = await airlinesDbContext.ManageFlights.FirstOrDefaultAsync(x => x.FlightId == id);
            if (existAirline != null)
            {
                existAirline.IsActive = airlines.IsActive;
                await airlinesDbContext.SaveChangesAsync();
            }
            return existAirline;
        }
    }
}
