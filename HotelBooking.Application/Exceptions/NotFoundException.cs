using Microsoft.AspNetCore.Http;

namespace HotelBooking.Application.Exceptions
{
    public class NotFoundException : AppException
    {
        public override int StatusCode { get; } = StatusCodes.Status404NotFound;
        public NotFoundException(string message) : base(message) { }
    }
}
