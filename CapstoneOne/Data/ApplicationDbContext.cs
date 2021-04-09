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
        }
        public DbSet<Customer> Customers
        {
            get; set;
        }
        public DbSet<Admin> Admins
        {
            get; set;
        }
    }
    }

