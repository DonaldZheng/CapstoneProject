using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneOne.Models
{
	public class ProductItem
	{
		[Key]
		public string ProductItemId {get; set;}

		public int Quantity { get; set; }

		public int ProductId { get; set; }

		public virtual Product Product { get; set; }





	}
}
