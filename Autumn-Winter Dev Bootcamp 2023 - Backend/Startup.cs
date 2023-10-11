using Autumn_Winter_Dev_Bootcamp_2023___Backend.Context;
using Autumn_Winter_Dev_Bootcamp_2023___Backend.Services;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autumn_Winter_Dev_Bootcamp_2023___Backend
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Autumn_Winter_Dev_Bootcamp_2023___Backend", Version = "v1" });
            });

            //Contexts
            services.AddDbContext<EmployerDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("JobListings")));
            services.AddDbContext<JobListingDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("JobListings")));
            services.AddDbContext<ApplicantDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("JobListings")));

            //Services
            services.AddScoped<EmployerServices>();
            services.AddScoped<JobListingServices>();
            services.AddScoped<ApplicantServices>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Autumn_Winter_Dev_Bootcamp_2023___Backend v1"));
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
