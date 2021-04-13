using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneOne.Models
{
    public class ShoppingCart
    {
        public string ShoppingCartId
        {
            get; set;
        }
        [ForeignKey("Product")]
        public string ProductId
        {
            get; set;
        }
        public Product product
        {
            get; set; 
        }
    }
}
