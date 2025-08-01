namespace HotelBooking.Application.Dtos.Client;

public record ClientRegisterDto(string FirstName, string LastName, string Email, string Password, string PhoneNumber, string Cpf, DateTime DateOfBirth);
