using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orders.API.Data;
using Orders.API.Repositories.Contracts;
using Orders.API.Repositories.Implementations;
using Orders.API.Services.Contracts;
using Orders.API.Services.Implementations;

namespace Orders.API
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
            // Injeccion de dependecias para Database InMemory
            services.AddDbContext<OrderContext>(options =>
                options.UseInMemoryDatabase(databaseName: "OrderDb")
            );

            // Mapper Config
            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Injeccion de dependencias para Repositorios
            services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();

            // Injeccion de dependencias para Servicios
            services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();

            // Swagger
            services.AddSwaggerGen();

            // Controllers
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Swagger
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Orders v1"));
            }

            // Poblar base de datos
            IServiceScope scope = app.ApplicationServices.CreateScope();
            OrderContext context = scope.ServiceProvider.GetRequiredService<OrderContext>();
            OrderSeed.PopulateDatabase(context);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}
