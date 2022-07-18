using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.API.Contracts.DTO
{
	public class UpdateOrderResponseDto
	{
		public int Id { get; set; }
		public DateTime OrderDateTime { get; set; }
		public int ShoppingCartId { get; set; }
		public bool isOrder { get; set; }
	}
}
