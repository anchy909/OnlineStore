using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnlineStore.API.Contracts.DTO;
using OnlineStore.Model;

namespace OnlineStore.API.Contracts.Mappers
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			CreateMap<Product, ProductResponseDto>().ReverseMap();
		}
	}
}
