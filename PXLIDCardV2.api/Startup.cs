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
using PXLIDCardV2.business.Contracts;
using PXLIDCardV2.business.Services;
using PXLIDCardV2.data;
using PXLIDCardV2.data.Contracts;
using PXLIDCardV2.data.Contracts.Evaluations;
using PXLIDCardV2.data.Contracts.Users;
using PXLIDCardV2.data.Repositories;
using PXLIDCardV2.data.Repositories.Evaluations;
using PXLIDCardV2.data.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PXLIDCardV2.api
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PXLIDCardV2.api", Version = "v1" });
            });
            services.AddDbContext<Context>(options =>
            {
                string connectionString = Configuration.GetConnectionString("ConnectionString");
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                });
                options.EnableSensitiveDataLogging();
            });


            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ILectorRepository, LectorRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IEvaluationRepository, EvaluationRepository>();
            services.AddScoped<IStudentEvaluationRepository, StudentEvaluationRepository>();

            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ILectorService, LectorService>();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PXLIDCardV2.api v1"));
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
