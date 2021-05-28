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
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Payments.API.Data;
using Payments.API.Repositories.Contracts;
using Payments.API.Repositories.Implementations;
using Payments.API.Services.Contracts;
using Payments.API.Services.Implementations;

namespace Payments.API
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
            services.AddDbContext<PaymentContext>(options =>
                options.UseInMemoryDatabase(databaseName: "PaymentDb")
            );

            // Mapper Config
            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Injeccion de dependencias para Repositorios
            services.AddScoped<IPaymentOrderRepository, PaymentOrderRepository> ();

            // Injeccion de dependencias para Servicios
            services.AddScoped<IPaymentOrderService, PaymentOrderService>();

            // Autentificacion
            //services.AddAuthentication("Bearer")
            //    .AddJwtBearer("Bearer", options =>
            //    {
            //        options.Authority = "http://localhost:5200";
            //        options.RequireHttpsMetadata = false;
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateAudience = false
            //        };
            //    });
            //// Autorizacion
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("ApiScope", policy =>
            //    {
            //        policy.RequireAuthenticatedUser();
            //        policy.RequireClaim("scope", "ApiGateway");
            //    });
            //});

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:5200";
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "ApiGateway";
                });

            // Swagger
            services.AddSwaggerGen();

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("V1", new OpenApiInfo { Title = "Prototype.Services.PaymentApi", Version = "v1" });
            //    //c.EnableAnnotations();
            //    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //    {
            //        Description = @"Ingrese 'Bearer' [space] y su Token",
            //        Name = "Authorization",
            //        In = ParameterLocation.Header,
            //        Type = SecuritySchemeType.ApiKey,
            //        Scheme = "Bearer"
            //    });
            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //        {
            //            new OpenApiSecurityScheme
            //            {
            //                Reference = new OpenApiReference
            //                {
            //                    Type = ReferenceType.SecurityScheme,
            //                    Id = "Bearer"
            //                },
            //                Scheme = "oauth2",
            //                Name = "Bearer",
            //                In = ParameterLocation.Header
            //            },
            //            new List<string>()
            //        }
            //    });
            //});



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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment v1"));
            }

            // Poblar base de datos
            IServiceScope scope = app.ApplicationServices.CreateScope();
            PaymentContext context = scope.ServiceProvider.GetRequiredService<PaymentContext>();
            PaymentSeed.PopulateDatabase(context);

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
