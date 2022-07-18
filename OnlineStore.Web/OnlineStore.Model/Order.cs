using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Model
{
	public class Order
	{
		public int Id { get; set; }
		public DateTime OrderDateTime { get; set; }
		public int ShoppingCartId { get; set; }
		public virtual ShoppingCart ShoppingCart { get; set; }
		public bool isOrder { get; set; }
	}
}
