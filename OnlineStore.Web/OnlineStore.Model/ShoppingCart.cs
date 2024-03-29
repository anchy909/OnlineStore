﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Model
{
	public class ShoppingCart
	{
		public int Id { get; set; }
		public string ShoppingCartMark { get; set; }
		public int Quantity { get; set; }
		public int ProductId { get; set; }
		public virtual Product Product { get; set; }
	}
}
