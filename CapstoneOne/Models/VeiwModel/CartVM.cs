using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneOne.Models.VeiwModel
{
	public class CartVM
	{
		public IEnumerable<Customer> Customers { get; set; }

		public IEnumerable<Product> Products{ get; set; }

		public IEnumerable<CustomerProduct> Carts { get; set; }
		//This is for many to many relashonship veiw model. Might use for Admen page.
	}
}
