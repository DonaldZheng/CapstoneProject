using CapstoneOne.Data;
using CapstoneOne.Models;
//using CapstoneOne.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CapstoneOne.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        //private GeocodingService _geocoding;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
            
        }
        // GET: CustomerController
        public IActionResult Index()
        {
            //ViewData["APIkeys"] = APIkeys.GoogleAPIKey;

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
            //ViewData["APIkeys"] = APIkeys.GoogleAPIKey;

            var customer = _context.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
            return View(customer);
        }

        // GET: CustomerController/Create
        public IActionResult Create()
        {
            Models.Customer customer = new Models.Customer();
            var packages = _context.Products.ToList();
            customer.Packages = new SelectList(packages,"ProductId","Name");
            return View(customer);
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CustomerId,FirstName,LastName,StreetName,City,State,ZipCode,Scheduler,Activity,Allergies,Packages,Anniversary,FavoritePlaces,Longtiude,Latitude,UserEmail")]Models.Customer customer, int productId)
        {

            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                //product = _context.Products.Add.ToList();
                
                // google geocoding the API CALL

                //var custromerwithLatLng = await _geocoding.GetGeoCoding(customer);

                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View();
            }
            //ViewBag.Products = new SelectList(product.Name, "Name", "Name");
            return View();


        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            //ViewData["APIkeys"] = APIkeys.GoogleAPIKey;

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
                //var custromerwithLatLng = await _geocoding.GetGeoCoding(customer);

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
        public IActionResult Delete(int id, Models.Customer customer)
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
        public IActionResult AddToCart(int id, Models.Product product)
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
        public static void EmailConfirm(Models.Customer customer)
        {
            Execute(customer).Wait();
        }
        public static async Task Execute(Models.Customer customer)
        {
            SmtpClient myCLient = new SmtpClient();
            myCLient.Credentials = new System.Net.NetworkCredential("test.email.for.ford@gmail.com", "Fofosho1@");
            myCLient.Port = 587;
            myCLient.Host = "smtp.gmail.com";
            myCLient.EnableSsl = true;
            myCLient.DeliveryMethod = SmtpDeliveryMethod.Network;
            myCLient.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("test.email.for.ford@gmail.com");
            mail.To.Add(customer.UserEmail);
            myCLient.Send(mail);
        }
        //Added for Payment
        //[Route("Pay")]
        //public async Task<dynamic> Pay(Models.Payment payment)
        //{
        //    return await MakePayment.PayAsync(payment.CardNumber, payment.Month, payment.Year, payment.Cvc, payment.Value);
        //}
        //public static async Task<dynamic> PayAsync(string CardNumber, int Month, int Year, string Cvc, int Value)
        //{
        //    try
        //    {
        //        StripeConfiguration.ApiKey = "sk_test_51IWr81I0mwyrhuJbwUsyQcLNrQKVQ508xWWR4I1lIh8fnMUaHk61JpUaZcI31wo2uEmAAAYge4L04dVBW0b7A9BH00BvfmxoVY";
        //        var optionstoken = new TokenCreateOptions
        //        {
        //            Card = new TokenCardOptions
        //            {
        //                Number = CardNumber,
        //                ExpMonth = Month,
        //                ExpYear = Year,
        //                Cvc = Cvc
        //            }
        //        };
        //        var servicetoken = new TokenService();
        //        Token stripetoken = await servicetoken.CreateAsync(optionstoken);
        //        var options = new ChargeCreateOptions
        //        {
        //            Amount = Value,
        //            Currency = "usd",
        //            Description = "test",
        //            Source = stripetoken.Id
        //        };
        //        var service = new ChargeService();
        //        Charge charge = await service.CreateAsync(options);
        //        if (charge.Paid)
        //        {
        //            return "Success";
        //        }
        //        else
        //        {
        //            return "Failed";
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return e.Message;
        //    }
        }
    }
//}


