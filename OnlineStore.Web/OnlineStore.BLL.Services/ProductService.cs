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
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;
		public ProductService(IProductRepository itemRepository)
		{
			_productRepository = itemRepository;
		}
		public Product UpdateProduct(int productId)
		{
			return _productRepository.UpdateProduct(productId);
		}
	}
}
