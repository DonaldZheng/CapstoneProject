using CapstoneOne.Data;
using CapstoneOne.Models;
using CapstoneOne.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CapstoneOne.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        private GeocodingService _geocoding;
        public CustomerController(ApplicationDbContext context, GeocodingService geocoding)
        {
            _context = context;
            _geocoding = geocoding;
        }
        // GET: CustomerController
        public IActionResult Index()
        {
            ViewData["APIkeys"] = APIkeys.GoogleAPIKey;

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).ToList();
            if (customer.Count == 0)
            {
                return RedirectToAction(nameof(Create));
            }

            return View(customer);
        }

        // GET: CustomerController/Details/5
        public IActionResult Details(int id)
        {
            ViewData["APIkeys"] = APIkeys.GoogleAPIKey;

            var customer = _context.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
            return View(customer);
        }

        // GET: CustomerController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                // google geocoding the API CALL

                var custromerwithLatLng = await _geocoding.GetGeoCoding(customer);

                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Console.WriteLine("Error");
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["APIkeys"] = APIkeys.GoogleAPIKey;

            var customer = _context.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Models.Customer customer)
        {
            try
            {
                var custromerwithLatLng = await _geocoding.GetGeoCoding(customer);

                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Console.WriteLine("Error");
                return View();
            }
        }


        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
            return View(customer);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Customer customer)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Console.WriteLine("Error");
                return View();
            }
        }
        public IActionResult AddToCart(int id, Product product)
        {
            try
            {
                _context.CustomerProducts.Include(p => product).Where(cp => cp.CustomerId == id);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                Console.WriteLine("Error");
                return View();
            }
          
            
        }
    }
}
