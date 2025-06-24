using HotelBooking.Domain.Enums;

namespace HotelBooking.Application.Dtos.User
{
    public record UserUpdateDto(string? PublicId,string? FirstName, string? LastName, string? Email, string? PhoneNumber, string? Cpf, DateTime? DateOfBirth, UserLevel? UserLevel, bool? IsActive, bool? EmailChecked);
}
