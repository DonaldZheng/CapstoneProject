using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CapstoneOne.Data;
using CapstoneOne.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CapstoneOne.Controllers
{
	public class CustomerProductController : Controller
	{
		private readonly ApplicationDbContext _context;

		public CustomerProductController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: CustomerProductController
		public IActionResult Index()
		{
			var cart = _context.CustomerProducts.Include(c => c.Product).ToList();
			return View(cart);
		}

		// GET: CustomerProductController/Details/5
		public IActionResult Details(int id)
		{
			var cart = _context.CustomerProducts.Where(e => e.ProductId == id).ToList();
			return View(cart);
		}

		// GET: CustomerProductController/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: CustomerProductController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(IFormCollection collection)
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

		// GET: CustomerProductController/Edit/5
		public IActionResult Edit(int id)
		{
			var cart = _context.CustomerProducts.Where(c => c.ProductId == id).FirstOrDefault();
			return View(cart);
		}

		// POST: CustomerProductController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, CustomerProduct cart)
		{
			try
			{
				_context.CustomerProducts.Update(cart);
				_context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				Console.WriteLine("Error");
				return View();
			}
		}

		// GET: CustomerProductController/Delete/5
		public IActionResult Delete(int id)
		{
			var cart = _context.CustomerProducts.Where(e => e.ProductId == id).FirstOrDefault();
			return View(cart);
		}

		// POST: CustomerProductController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(int id, CustomerProduct cart)
		{
			try
			{
				//var  = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
				//cart.ProductId = ;
				//_context.Customers.Remove(cart);
				//_context.SaveChanges();
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
