using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.API.Contracts.DTO
{
	public class AddCartResponseDto : CartRequestDto
	{
		public string ShoppingCartMark { get; set; }
	}
}
