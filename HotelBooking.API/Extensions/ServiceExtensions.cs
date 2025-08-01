using HotelBooking.Application.Interfaces.Services;
using HotelBooking.Application.Services;

namespace HotelBooking.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserPasswordHasher, UserPasswordHasherService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IClientService, ClientService>();

            return services;
        }
    }
}
