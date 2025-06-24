namespace HotelBooking.Application.Interfaces.Services
{
    public interface IUserPasswordHasher
    {
        string HashPassword(string rawPassword);
        bool VerifyPassword(string hashedPassword, string rawPassword);
    }
}
