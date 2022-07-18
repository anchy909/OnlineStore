using AutoMapper;
using OnlineStore.API.Contracts.DTO;
using OnlineStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.API.Contracts.Mappers
{
	public class OrderProfile : Profile
	{
		public OrderProfile()
		{
			CreateMap<Order, UpdateOrderResponseDto>().ReverseMap();
		}
	}
}
