namespace HotelBooking.Application.Dtos.User
{
    public record UserRegisterDto(string FirstName, string LastName, string Email, string Password, string PhoneNumber, string Cpf, DateTime DateOfBirth);
}
