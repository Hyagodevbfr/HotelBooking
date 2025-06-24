using Microsoft.AspNetCore.Http;

namespace HotelBooking.Application.Exceptions
{
    public abstract class AppException : Exception
    {
        public virtual int StatusCode { get; } = StatusCodes.Status500InternalServerError;

        protected AppException(string message) : base(message) { }
    }
}
