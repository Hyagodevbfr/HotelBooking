using HotelBooking.Domain.Enums;

namespace HotelBooking.Application.Dtos.Client;

public record ClientResponseDto(
    string Id, string PublicId,
    string FirstName, string LastName,
    string Email, string PhoneNumber,
    string Cpf, DateTime DateOfBirth,
    UserLevel UserLevel, bool IsActive, bool EmailChecked);
