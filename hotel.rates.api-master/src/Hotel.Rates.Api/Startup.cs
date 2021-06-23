using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Rates.Core.Interfaces;
using Hotel.Rates.Core.Services;
using Hotel.Rates.Data;
using Hotel.Rates.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Hotel.Rates.Api
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
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;
            services.AddDbContext<InventoryContext>((s, o) => o.UseSqlite("Data Source=data.db"));
            services.AddScoped(typeof(IRepository<,>), typeof(EntityFrameworkRepository<,>));
            services.AddScoped<INightlyRatePlanRepository, NightlyRatePlanRepository>();
            services.AddScoped<IIntervalRatePlanRepository, IntervalRatePlanRepository>();
            services.AddScoped<IRatePlanRepository, RatePlanRepository>();
            services.AddScoped<IRatePlanRoomRepository, RatePlanRoomRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<ISeasonRepository, SeasonRepository>();
            services.AddScoped<IRatePlanService, RatePlanService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IReservationService, ReservationService>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<InventoryContext>();
                context.Database.EnsureCreated();
            }


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
        }
    }
}
