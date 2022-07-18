using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineStore.BLL.Infrastructure;
using OnlineStore.BLL.Services;
using OnlineStore.DAL.Infrastructure;
using OnlineStore.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.API.Contracts.Mappers;

namespace OnlineStore.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddDbContext<StoreDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("StoreDatabase")));

			services.AddRazorPages();
			//repository
			services.AddTransient<IProductRepository, ProductRepository>();
			services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
			services.AddTransient<IOrderRepository, OrderRepository>();
			//services
			services.AddTransient<IProductService, ProductService>();
			services.AddTransient<IShoppingCartService, ShoppingCartService>();
			services.AddTransient<IOrderService, OrderService>();

			services.AddControllers().AddNewtonsoftJson();
			
			 services.AddControllers().AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.IgnoreNullValues = true;
			});

			var mapperConfig = new AutoMapper.MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new ShoppingCartProfile());
				cfg.AddProfile(new ProductProfile());
				cfg.AddProfile(new OrderProfile());
			});

			var mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
				endpoints.MapControllers();
			});
		}
	}
}
