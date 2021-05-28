using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Purchase.Aggregator.Services.Contracts;
using Purchase.Aggregator.Services.Implementations;

namespace Purchase.Aggregator
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
            // Injeccion de dependencias para Servicios HttpClient
            services.AddHttpClient<ICatalogService, CatalogService>(client =>
                client.BaseAddress = new Uri(Configuration["ApiSettings:CatalogUrl"]));

            services.AddHttpClient<IPaymentService, PaymentService>(client =>
                client.BaseAddress = new Uri(Configuration["ApiSettings:PaymentsUrl"]));

            services.AddHttpClient<IOrderService, OrderService>(client =>
                client.BaseAddress = new Uri(Configuration["ApiSettings:OrdersUrl"]));

            // Injeccion de dependencias para Servicios
            services.AddScoped<IPaymentInputService, PaymentInputService>();

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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Purchase.Aggregator v1"));
            }

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
