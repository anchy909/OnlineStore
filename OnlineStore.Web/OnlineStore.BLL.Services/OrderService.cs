using OnlineStore.BLL.Infrastructure;
using OnlineStore.DAL.Infrastructure;
using OnlineStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;
		public OrderService(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}
		public Order UpdateOrder(int orderId)
		{
			return _orderRepository.UpdateOrder(orderId);
		}
	}
}
