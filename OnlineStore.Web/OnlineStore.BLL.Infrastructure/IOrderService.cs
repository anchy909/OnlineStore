using OnlineStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Infrastructure
{
	public interface IOrderService
	{
		Order UpdateOrder(int orderId);
	}
}
