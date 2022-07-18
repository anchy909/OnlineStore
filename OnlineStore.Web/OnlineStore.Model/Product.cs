using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Model
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		[Column(TypeName = "decimal(18,4)")]
		public decimal Price { get; set; }
		[Column(TypeName = "decimal(18,4)")]
		public decimal Discount { get; set; }
	}
}
