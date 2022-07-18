using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.Contracts.DTO;
using OnlineStore.BLL.Infrastructure;
using OnlineStore.DAL.Infrastructure.Exceptions;

namespace OnlineStore.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;
		private readonly IMapper _mapper;
		public OrderController(IOrderService orderService, IMapper mapper)
		{
			_orderService = orderService;
			_mapper = mapper;
		}
		[HttpPut]
		[Route("{id}")]
		public ActionResult Update([FromRoute] int id)
		{
			try
			{
				return Ok(_mapper.Map<UpdateOrderResponseDto>(_orderService.UpdateOrder(id)));
			}
			catch (EntityNotFoundException e)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
			}
		}
	}
}
