using Microsoft.AspNetCore.Http;

namespace HotelBooking.Application.Exceptions
{
    public class UnauthorizedException : AppException
    {
        public override int StatusCode { get; } = StatusCodes.Status401Unauthorized;
        public UnauthorizedException(string message) : base(message) { }
    }
}
