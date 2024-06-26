using DependencyInjectionContainer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PresentationLayer.Context;
using PresentationLayer.Mapper;
namespace PresentationLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddScoped<MapModelToViewModel>();
            builder.Services.AddHotelBookingServices(builder.Configuration);
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddDbContext<BookingIdentityDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnections")));
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<BookingIdentityDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Booking}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
