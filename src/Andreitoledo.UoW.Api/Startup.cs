﻿using Andreitoledo.UoW.Api.Controllers.Mapper;
using Andreitoledo.UoW.Data.FailedRepository;
using Andreitoledo.UoW.Data.Orm;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Andreitoledo.UoW.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configureservices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.AddScoped<IPessoaFailedRepository, PessoaFailedRepository>();
            services.AddScoped<IVooFailedRepository, VooFailedRepository>();

            services.AddDbContext<UoWDbContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"));
            });
        
                

            services.AddControllers();

            services.AddSwaggerGen(c=>
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "UoW - Unit Of Work Pattern - API",
                Description = "Esta API serve recursos do Sistema para testar o Unit Of Work Pattern",
                Contact = new OpenApiContact()
                {
                    Name = "Andrei Toledo",
                    Email = "altsystems@outlook.com.br",
                    Url = new Uri("https://github.com/andreitoledo")
                },
                License = new OpenApiLicense()
                {
                    Name = "MIT",
                    Url = new Uri("https://opensource.org/licenses/MIT")
                }

            }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        { 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Unit Of Work v1"));

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        
        }


    }
}
