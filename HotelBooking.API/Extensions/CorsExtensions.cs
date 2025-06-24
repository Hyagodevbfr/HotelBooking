using HotelBooking.Application.Configurations;

namespace HotelBooking.API.Extensions
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddCustomCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CorsSettings>(configuration.GetSection("Cors"));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    var corsOrigins = configuration.GetSection("Cors:Origins").Get<string[]>() ?? Array.Empty<string>();

                    builder
                        .WithOrigins(corsOrigins)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            return services;
        }
    }
}
