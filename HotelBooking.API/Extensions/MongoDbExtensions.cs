using HotelBooking.Infrastructure.Data.Mongo;
using HotelBooking.SharedKernel.Settings;

namespace HotelBooking.API.Extensions
{
    public static class MongoDbExtensions
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
            services.AddSingleton<MongoDbContext>();

            return services;
        }
    }
}
