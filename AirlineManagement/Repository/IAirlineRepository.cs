using AirlineManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineManagement.Repository
{
    public interface IAirlineRepository
    {
        Task<List<Airline>> GetAirlines();
        Task InsertAirline(Airline airline);
        Task CancelAirline(string airlineNo);
    }
}
