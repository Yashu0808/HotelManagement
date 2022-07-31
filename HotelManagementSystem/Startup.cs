using AspNetCoreRateLimit;
using AutoMapper;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared;

namespace HotelManagementSystem
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

            services.AddDbContext<HotelDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("myconn"));
                options.EnableSensitiveDataLogging();
            }
            );

            services.AddMemoryCache();
            services.AddHttpContextAccessor();

            services.AddCors(o =>
            {
                o.AddPolicy("AllowAll", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.ConfigureAutoMapper();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
            services.ConfigureRateLimiting();
            services.AddCustomSwagger();

            services.AddControllers().AddNewtonsoftJson(op =>
            op.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Hotel management API");
            });

            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseResponseCaching();
            app.UseIpRateLimiting();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
