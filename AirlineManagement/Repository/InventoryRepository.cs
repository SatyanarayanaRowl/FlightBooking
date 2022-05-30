using AirlineManagement.DBContext;
using AirlineManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineManagement.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly AirlineDbContext _inventoryContext;
        public InventoryRepository(AirlineDbContext context)
        {
            _inventoryContext = context;
        }
        public IEnumerable<InventoryTbl> GetInventory()
        {
           // Response response = new Response();
            try
            {
                var res = _inventoryContext.inventoryTbls.ToList();
                if (res.Count == 0)
                    throw new Exception("No Inventory exists");
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddInventory(InventoryTbl tbl)
        {
            try
            {
                var res = _inventoryContext.inventoryTbls.Where(x => x.FlightNumber.ToLower() == tbl.FlightNumber.ToLower()).ToList();
                if (res.Count != 0)
                    throw new Exception("Inventory for airline " + tbl.AirlineNo + " is alreday exists in system");
                _inventoryContext.inventoryTbls.Add(tbl);
                _inventoryContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public IEnumerable<InventoryTbl> GetAllFlightBasedUponPlaces(string fromplace, string toplace)
        {
            try
            {
                var res = _inventoryContext.inventoryTbls.Where(x => x.ToPlace.ToLower() == toplace.ToLower() && x.FromPlace.ToLower() == fromplace.ToLower()).ToList();
                if (res.Count == 0)
                    throw new Exception("No Flight exists");
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
