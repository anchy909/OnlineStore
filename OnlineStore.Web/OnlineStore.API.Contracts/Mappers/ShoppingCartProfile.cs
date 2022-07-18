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
	public class ShoppingCartProfile : Profile
	{
		public ShoppingCartProfile()
		{
			CreateMap<ShoppingCart, AddCartRequestDto>().ReverseMap();
			CreateMap<ShoppingCart, CartRequestDto>().ReverseMap();
			CreateMap<ShoppingCart, AddCartResponseDto>().ReverseMap();
		}
	}
}
