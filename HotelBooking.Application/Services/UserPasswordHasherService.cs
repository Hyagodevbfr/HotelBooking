using HotelBooking.Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace HotelBooking.Application.Services
{
    public class UserPasswordHasherService : IUserPasswordHasher
    {
        private readonly PasswordHasher<object> _hasher = new();

        public string HashPassword(string rawPassword)
        {
            return _hasher.HashPassword(null!, rawPassword);
        }

        public bool VerifyPassword(string hashedPassword, string rawPassword)
        {
            var result = _hasher.VerifyHashedPassword(null!, hashedPassword, rawPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
