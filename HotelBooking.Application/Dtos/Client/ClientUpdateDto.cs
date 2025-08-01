using HotelBooking.Domain.Enums;

namespace HotelBooking.Application.Dtos.Client;

public record ClientUpdateDto(string? PublicId,string? FirstName, string? LastName, string? Email, string? PhoneNumber, string? Cpf, DateTime? DateOfBirth, bool? IsActive, bool? EmailChecked);
