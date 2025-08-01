using HotelBooking.Application.Dtos.Client;
using HotelBooking.Application.Dtos.User;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;

namespace HotelBooking.Application;

public static class ClientMappingExtensions
{
    // This method maps a ClientRegisterDto to a UserRegisterDto.
    public static UserRegisterDto ToUserRegisterDto(this ClientRegisterDto clientRegisterDto)
    {
        return new UserRegisterDto(
            clientRegisterDto.FirstName,
            clientRegisterDto.LastName,
            clientRegisterDto.Email,
            clientRegisterDto.Password,
            clientRegisterDto.PhoneNumber,
            clientRegisterDto.Cpf,
            clientRegisterDto.DateOfBirth);
    }

    // This method maps a UserResponseDto to a ClientResponseDto.
    public static ClientResponseDto ToResponse(this UserResponseDto userResponseDto)
    {
        return new ClientResponseDto(
            userResponseDto.Id,
            userResponseDto.PublicId,
            userResponseDto.FirstName,
            userResponseDto.LastName,
            userResponseDto.Email,
            userResponseDto.PhoneNumber,
            userResponseDto.Cpf,
            userResponseDto.DateOfBirth,
            userResponseDto.UserLevel,
            userResponseDto.IsActive,
            userResponseDto.EmailChecked
            );
    }

    // This method maps a ClientUpdateDto to a UserUpdateDto.
    public static UserUpdateDto ToUserUpdateDto(this ClientUpdateDto clientUpdateDto)
    {
        return new UserUpdateDto(
            clientUpdateDto.PublicId,
            clientUpdateDto.FirstName,
            clientUpdateDto.LastName,
            clientUpdateDto.Email,
            clientUpdateDto.PhoneNumber,
            clientUpdateDto.Cpf,
            clientUpdateDto.DateOfBirth,
            UserLevel.Client,
            clientUpdateDto.IsActive,
            clientUpdateDto.EmailChecked
        );
    }
}
