using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CustomerAPIServices.Controllers
{
    public class CustomersController : Controller
    {
        [Authorize]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Catcher Wong", "James Li" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"Catcher Wong - {id}";
        }

        /*
        // GET: CustomersController
        public ActionResult Index()
        {
            return View();
        }
 
        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
 
        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }
 
        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
 
        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
 
        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
 
        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
 
        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}