using OnlineStore.DAL.Infrastructure;
using OnlineStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DAL.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly StoreDbContext _dbContext;
		public ProductRepository(StoreDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public Product UpdateProduct(int productId)
		{
			var product = _dbContext.Products.SingleOrDefault(p => p.Id == productId);
			if (product == null)
			{
				throw new EntryPointNotFoundException("Product does not exist");
			}
			decimal markdown = Math.Round((product.Discount / 100m) * product.Price, 2);
			decimal discountedPrice = product.Price - markdown;
			product.Price = discountedPrice;
			_dbContext.Update(product);
			_dbContext.SaveChanges();
			return product;
		}
	}
}
