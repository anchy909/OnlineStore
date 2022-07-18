using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.Contracts.DTO;
using OnlineStore.BLL.Infrastructure;
using OnlineStore.DAL.Infrastructure.Exceptions;
using OnlineStore.Model;
using System;
using System.Threading.Tasks;

namespace OnlineStore.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShoppingCartController : ControllerBase
	{
		private readonly IShoppingCartService _shoppingCartService;
		private readonly IMapper _mapper;
		public ShoppingCartController(IShoppingCartService shoppingCartService, IMapper mapper)
		{
			_shoppingCartService = shoppingCartService;
			_mapper = mapper;
		}
		[HttpPost]
		public ActionResult AddToShoppingCart([FromBody] AddCartRequestDto cartRequestDto)
		{
			try
			{
				var shoppingCart = _mapper.Map<ShoppingCart>(cartRequestDto);
				return Ok(_mapper.Map<AddCartResponseDto>(_shoppingCartService.AddToShoppingCart(shoppingCart)));
			}
			catch (Exception e)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
			}
		}

		[HttpDelete]
		[Route("{id}/{shoppingCartItem}")]
		public ActionResult Delete([FromRoute] int id, string shoppingCartItem)
		{
			try
			{
				_shoppingCartService.DeleteShoppingCart(id, shoppingCartItem);
				return NoContent();
			}
			catch (EntityNotFoundException e)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
			}
		}

		[HttpGet]
		[Route("{shoppingCartItem}")]
		public ActionResult GetTotalPrice([FromRoute] string shoppingCartItem)
		{
			try
			{
				return Ok(_shoppingCartService.GetTotalPrice(shoppingCartItem));
			}
			catch (EntityNotFoundException e)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
			}

		}
	}
}
