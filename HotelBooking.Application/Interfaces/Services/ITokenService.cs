using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
