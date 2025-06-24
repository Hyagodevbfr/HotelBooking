using HotelBooking.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.API.Extensions
{
    public static class ValidationExtensions
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var result = new ResponseView<object>(
                        isSuccess: false,
                        message: "Invalid data provided.",
                        data: null
                        );
                    return new BadRequestObjectResult(result);
                };
            });
            return services;
        }
    }
}
