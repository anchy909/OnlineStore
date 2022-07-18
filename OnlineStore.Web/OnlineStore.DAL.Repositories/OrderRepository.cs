using OnlineStore.DAL.Infrastructure;
using OnlineStore.DAL.Infrastructure.Exceptions;
using OnlineStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DAL.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly StoreDbContext _dbContext;

		public OrderRepository(StoreDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public Order UpdateOrder(int oriderId)
		{
			var order = _dbContext.Orders.SingleOrDefault(c => c.Id == oriderId);
			if (order == null)
			{
				throw new EntityNotFoundException("Order does not exist.");
			}
			else
			{
				order.isOrder = true;
				_dbContext.Update(order);
				_dbContext.SaveChanges();
				return order;
			}
		}
	}
}
