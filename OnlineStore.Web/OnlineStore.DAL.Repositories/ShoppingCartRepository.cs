using Microsoft.EntityFrameworkCore;
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
	public class ShoppingCartRepository : IShoppingCartRepository
	{
		private readonly StoreDbContext _dbContext;

		public ShoppingCartRepository(StoreDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public ShoppingCart AddToShoppingCart(ShoppingCart shoppingCart)
		{
			var cartItem = GetCart(shoppingCart.ShoppingCartMark, shoppingCart.ProductId);
			if (cartItem == null)
			{
				cartItem = new ShoppingCart
				{
					ProductId = shoppingCart.ProductId,
					ShoppingCartMark = shoppingCart.ShoppingCartMark,
					Product = _dbContext.Products.SingleOrDefault(p => p.Id == shoppingCart.ProductId),
					Quantity = shoppingCart.Quantity,
				};
				_dbContext.ShoppingCarts.Add(cartItem);
			}
			else
			{
				cartItem.Quantity = shoppingCart.Quantity;
			}
			_dbContext.SaveChanges();
			return shoppingCart;
		}

		public void DeleteShoppingCart(int productId, string shoppingCartMark)
		{
			var cartItem = GetCart(shoppingCartMark, productId);
			if (cartItem != null)
			{
				_dbContext.ShoppingCarts.Remove(cartItem);
				_dbContext.SaveChanges();
			}
			else
			{
				throw new EntityNotFoundException("Error while deleting product");
			}
		}

		public ShoppingCart GetCart(string shoppingCartMark, int productId)
		{
			return _dbContext.ShoppingCarts.SingleOrDefault(c => c.ShoppingCartMark == shoppingCartMark && c.ProductId == productId);
		}


		public decimal GetTotalPrice(string shoppingCardMark)
		{
			var cartItem = _dbContext.ShoppingCarts.SingleOrDefault(c => c.ShoppingCartMark == shoppingCardMark);
			if (cartItem == null)
			{
				throw new EntityNotFoundException("Shopping cart does not exist.");
			}
			return _dbContext.ShoppingCarts.Where(s => s.ShoppingCartMark == shoppingCardMark).Select(s => s.Quantity * s.Product.Price).Sum();
		}
	}
}
