using HotelBooking.Domain.Interfaces.Repositories;
using HotelBooking.Infrastructure.Repositories;

namespace HotelBooking.API.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();

            return services;
        }
    }
}
