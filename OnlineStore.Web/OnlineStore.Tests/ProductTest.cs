using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NUnit.Framework;
using OnlineStore.BLL.Infrastructure;
using OnlineStore.BLL.Services;
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
	public class ProductTest
	{
		private IQueryable<Product> _products;
		private Product _product;

		[SetUp]
		public void Setup()
		{
			_products = new List<Product>()
			{
				new Product { Id = 1},
				new Product { Id = 2 },
				new Product { Id = 3},
				new Product { Id = 4},
			}.AsQueryable();

			_product = new Product();
			_product.Id = 10;
		}

		[TestMethod]
		public void CheckIfProductServiceIsNotFull()
		{
			var productService = Substitute.For<IProductService>();
			var product = new Product { Id = 1, Name = "Oven", Discount = 3, Price = 12.34m };
			Assert.IsNotNull(productService);
			Assert.IsNotNull(productService.UpdateProduct(1).Returns(product));
		}
	}
}
