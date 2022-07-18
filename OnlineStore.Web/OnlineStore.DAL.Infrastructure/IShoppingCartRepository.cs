using OnlineStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DAL.Infrastructure
{
	public interface IShoppingCartRepository
	{
		ShoppingCart AddToShoppingCart(ShoppingCart shoppingCart);
		void DeleteShoppingCart(int productId, string shoppingCartMark);
		decimal GetTotalPrice(string shoppingCardMark);
	}
}
