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
	public class ShoppingCartService : IShoppingCartService
	{
		private readonly IShoppingCartRepository _iShoppingCartRepository;

		public ShoppingCartService(IShoppingCartRepository iShoppingCartRepository)
		{
			_iShoppingCartRepository = iShoppingCartRepository;
		}
		public ShoppingCart AddToShoppingCart(ShoppingCart shoppingCart)
		{
			return _iShoppingCartRepository.AddToShoppingCart(shoppingCart);
		}

		public void DeleteShoppingCart(int productId, string shoppingCardMark)
		{
			_iShoppingCartRepository.DeleteShoppingCart(productId, shoppingCardMark);
		}

		public decimal GetTotalPrice(string shoppingCardMark)
		{
			return _iShoppingCartRepository.GetTotalPrice(shoppingCardMark);
		}
	}
}
