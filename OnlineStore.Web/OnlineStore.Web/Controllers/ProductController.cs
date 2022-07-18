using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OnlineStore.BLL.Infrastructure;
using OnlineStore.Model;
using AutoMapper;
using OnlineStore.API.Contracts.DTO;
using OnlineStore.DAL.Infrastructure.Exceptions;

namespace OnlineStore.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;
		public ProductController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}
		[HttpPut]
		[Route("{id}")]
		public ActionResult Update([FromRoute] int id)
		{
			try
			{
				return Ok(_mapper.Map<ProductResponseDto>(_productService.UpdateProduct(id)));
			}
			catch (EntityNotFoundException e)
			{
				return NotFound(e.Message);
			}
		}
	}
}
