using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Restaurant.Db;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant
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
            services.AddControllers();

            
            services.AddLamar(new ApplicationRegistry());
            services.AddDbContext<RestaurantDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("FoodContextConnectionString")));

            services.AddSwaggerGen();
            services.AddSwaggerGen(swag =>
            {
                swag.SwaggerDoc("v0", new OpenApiInfo { Title = "Restaurant", Version = "v0" });
                var basePath = AppContext.BaseDirectory;

                var xmlPath = Path.Combine(basePath, "Restaurant.xml");
                swag.IncludeXmlComments(xmlPath);

                swag.DescribeAllParametersInCamelCase();
                swag.CustomSchemaIds(i => i.FullName);
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseSwagger();
            app.UseSwaggerUI(x => x.SwaggerEndpoint("v0/swagger.json", "Restaurant"));
        }
    }
}
