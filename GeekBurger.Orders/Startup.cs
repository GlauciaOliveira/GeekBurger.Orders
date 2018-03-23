﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using GeekBurger.Orders.Service;
using GeekBurger.Orders.Repository;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;
using GeekBurger.Orders.Extension;

namespace GeekBurger.Orders
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var mvcCoreBuilder = services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Orders", Version = "v1" });
            });

            services.AddAutoMapper();

            services.AddDbContext<OrdersContext>(o => o.UseInMemoryDatabase("geekburger-orders"));
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            //services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddSingleton<IOrderPaidService, OrderPaidService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, OrdersContext ordersContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            ordersContext.Seed();
        }
    }
}
