using ManagerChannel.Data;
using ManagerChannel.Services;
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

namespace ManagerChannel
{
    public class Startup
    {
        public static IServiceProvider ServiceProvider;
        public static string ApplicationDbConnection;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ApplicationDbConnection = Configuration.GetConnectionString("ApplicationDbConnection");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ManagerChannel", Version = "v1" });
            });
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(ApplicationDbConnection, sqlOptions =>
                {
                    sqlOptions.MigrationsHistoryTable("__ApplicationEFMigrationsHistory");
                });
            });

            services.AddSingleton<Interfaces.ILogger, FileLogger>();
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

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
