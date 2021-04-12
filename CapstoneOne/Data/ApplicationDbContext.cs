using CapstoneOne.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneOne.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"

            },
            new IdentityRole
            {
                Name = "Customer",
                NormalizedName = "CUSTOMER"
            }
            );
            builder.Entity<Product>()
            .HasData(
                    new Product { ProductId = 1, Name = "Planner Package", Description = "Let Us Do All The Planning For Your Date!", Price = 35 },
                    new Product { ProductId = 2, Name = "Reminder Package", Description = "Text/Email/Location Reminders", Price = 25 },
                    new Product { ProductId = 3, Name = "Transport Package", Description = "Too Lazy? We'll Pick You Up!", Price = 500 },
                    new Product { ProductId = 4, Name = "Deluxe Package", Description = "Includes: Vacations, Hotels, Flights", Price = 1000 },
                    new Product { ProductId = 5, Name = "Custom Package", Description = "Customize Your Own Package!", Price = 200 }
            );
        }
        public DbSet<Customer> Customers
        {
            get; set;
        }
        public DbSet<Admin> Admins
        {
            get; set;
        }
        public DbSet<Product> Products
        {
            get; set;
        }
    }
    }

