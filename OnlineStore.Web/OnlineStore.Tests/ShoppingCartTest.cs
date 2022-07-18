using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NUnit.Framework;
using OnlineStore.BLL.Infrastructure;
using OnlineStore.Model;
using OnlineStore.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace OnlineStore.Tests
{
	[TestClass]
	public class ShoppingCartTest
	{
		private IQueryable<ShoppingCart> _shoppingCarts;
		private ShoppingCart _shoppingCart;

		[SetUp]
		public void Setup()
		{
			_shoppingCarts = new List<ShoppingCart>()
			{
				new ShoppingCart { Id = 1},
				new ShoppingCart { Id = 2 },
				new ShoppingCart { Id = 3},
				new ShoppingCart { Id = 4},
			}.AsQueryable();

			_shoppingCart = new ShoppingCart();
			_shoppingCart.Id = 10;
		}

		[TestMethod]
		public void CheckIfShoppingCartServiceIsNotFull()
		{
			var shoppingCartService = Substitute.For<IShoppingCartService>();
			Assert.IsNotNull(shoppingCartService);
		}
	}
}
