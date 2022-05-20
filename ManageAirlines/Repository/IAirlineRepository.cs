using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageAirlines.Models;

namespace ManageAirlines.Repository
{
    public interface IAirlineRepository
    {
        Task<List<Airlines>> GetAllFlights();
        Task<Airlines> GetFlight(int id);
        Task InsertAirline(Airlines airlines);
        Task<Airlines> CancelAirline(int id, Airlines airlines);

    }
}
