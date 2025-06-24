using Microsoft.AspNetCore.Http;

namespace HotelBooking.Application.Exceptions
{
    public abstract class BadRequestException : AppException
    {
        public override int StatusCode { get; } = StatusCodes.Status400BadRequest;

        public BadRequestException(string message) : base(message) { }
    }
}
