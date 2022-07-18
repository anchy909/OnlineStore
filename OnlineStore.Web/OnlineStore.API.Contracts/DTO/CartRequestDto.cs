﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.API.Contracts.DTO
{
	public class CartRequestDto
	{
		[Required]
		public int ProductId { get; set; }
		[Required]
		public int Quantity { get; set; }
	}
}
