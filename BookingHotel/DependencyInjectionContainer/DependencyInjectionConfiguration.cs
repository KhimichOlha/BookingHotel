using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Repositories.Interfases;
using DataAccessLayer.Repositories.Servises;


namespace DependencyInjectionContainer
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddHotelBookingServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HotelBookingDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("HotelBookingDataBase")));
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IGuestRepository, GuestRepository>();
            services.AddScoped<IGuestService, GuestService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<INotificationService, EmailNotificationService>();
            services.AddScoped<IPricing, StandardPrice>();
            services.AddScoped<IBookingState, PendingBookingState>();
            services.AddScoped<IAmenitieRepository, AmenitieRepository>();




            return services;

        }
    }
}
