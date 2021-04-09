﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneOne.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId
        {
            get; set;
        }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is a Required Input")]
        public string FirstName
        {
            get; set;
        }
        [Display(Name = "Last Name")]
        public string LastName
        {
            get; set;
        }
        [Display(Name = "StreetName")]
        public string StreetName
        {
            get; set;
        }

        [Display(Name = "City")]
        public string City
        {
            get; set;
        }
        [Display(Name = "State")]
        public string State
        {
            get; set;
        }
        [Display(Name = "ZipCode")]
        public string ZipCode
        {
            get; set;
        }
        [Display(Name = "Favorite Date Activity?")]
        public string Date
        {
            get; set;
        }
        [ForeignKey("IdentityUser")]
        public string IdentityUserId
        {
            get; set;
        }
        public IdentityUser IdentityUser
        {
            get; set;
        }
    }
}
