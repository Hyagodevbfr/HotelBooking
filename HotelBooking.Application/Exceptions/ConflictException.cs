using Microsoft.AspNetCore.Http;

namespace HotelBooking.Application.Exceptions
{
    public class ConflictException : AppException
    {
        public override int StatusCode { get; } = StatusCodes.Status409Conflict;
        public ConflictException(string message) : base(message) { }
    }
}
