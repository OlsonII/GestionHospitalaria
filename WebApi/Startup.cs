using System;
using Domain.Contracts;
using Infrastructure;
using Infrastructure.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace WebApi
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
            services.AddDbContext<MedicalContext>(opt =>
                opt.UseSqlServer(
                    "Server=DESKTOP-N95GP02\\SQLEXPRESS01;Database=MedicalServices;Trusted_Connection=True;MultipleActiveResultSets=true"));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbContext, MedicalContext>();

            services.AddCors(options =>
                {
                    options.AddPolicy("Flutter",
                        builder =>
                        {
                            builder.WithOrigins("http://localhost").AllowAnyOrigin().WithMethods("PUT", "POST", "GET");
                            builder.WithOrigins("http://192.168.0.28").AllowAnyOrigin()
                                .WithMethods("PUT", "POST", "GET");
                        });
                }
            );

            services.AddControllers();

            #region SwaggerOpen Api

            //Register the Swagger services
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Servicios Medicos",
                    Description = "Servicios Medicos - ASP.NET Core Web API",
                    TermsOfService = new Uri("https://cla.dotnetfoundation.org/"),
                    Contact = new OpenApiContact
                    {
                        Name = "OlsonLabs",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/OlsonII/MedicalServices")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licencia dotnet foundation",
                        Url = new Uri("https://www.byasystems.co/license")
                    }
                });
            });

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseCors("Flutter");
            app.UseRouting();

            app.UseAuthorization();

            #region Activar SwaggerUI

            app.UseSwagger();
            app.UseSwaggerUI(
                options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "Servicios Medicos v1"); }
            );

            #endregion

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}