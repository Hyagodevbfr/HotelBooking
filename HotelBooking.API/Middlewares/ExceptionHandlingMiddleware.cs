using HotelBooking.Application.Exceptions;
using System.Text.Json;

namespace HotelBooking.API.Middlewares
{
        public class ExeptionHandlingMiddleware
        {
            private readonly RequestDelegate _next;

            public ExeptionHandlingMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task InvokeAsync(HttpContext context)
            {
                try
                {
                    await _next(context);
                }
                catch (AppException ex)
                {
                    await HandleExceptionAsync(context, ex.StatusCode, ex.Message);
                }
                catch (Exception ex)
                {
                    await HandleExceptionAsync(context, StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            private static async Task HandleExceptionAsync(HttpContext context, int statusCode, string message)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;

                var result = JsonSerializer.Serialize(new { error = message });

                await context.Response.WriteAsync(result);
            }
        }
}
