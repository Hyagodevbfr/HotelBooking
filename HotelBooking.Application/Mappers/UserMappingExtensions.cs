using HotelBooking.Application.Dtos.User;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;
using HotelBooking.Application.Interfaces.Services;

namespace HotelBooking.Application.Mappers
{
    public static class UserMappingExtensions
    {

        public static User ToEntity(this UserRegisterDto userDto, string passwordHashed)
        {
            return new User(
                firstName: userDto.FirstName,
                lastName: userDto.LastName,
                email: userDto.Email,
                passwordHash: passwordHashed,
                phoneNumber: userDto.PhoneNumber,
                cpf: userDto.Cpf,
                dateOfBith: userDto.DateOfBirth,
                userLevel: UserLevel.Client,
                isActive: true,
                emailChecked: true // Change to false when validation email will be implemented
                );
        }

        public static UserResponseDto ToResponse(this User user)
        {
            return new UserResponseDto(
                Id: user.Id.ToString(),
                PublicId: user.PublicId.ToString(),
                FirstName: user.FirstName,
                LastName: user.LastName,
                Email: user.Email,
                PhoneNumber: user.PhoneNumber,
                Cpf: user.Cpf,
                DateOfBirth: user.DateOfBirth,
                UserLevel: user.UserLevel,
                IsActive: user.IsActive,
                EmailChecked: user.EmailChecked
            );
        }

        public static UserUpdateDto ToUpdate(this User user)
        {
            return new UserUpdateDto(
                PublicId: user.PublicId.ToString(),
                FirstName: user.FirstName,
                LastName: user.LastName,
                Email: user.Email,
                PhoneNumber: user.PhoneNumber,
                Cpf: user.Cpf,
                DateOfBirth: user.DateOfBirth,
                UserLevel: user.UserLevel,
                IsActive: user.IsActive,
                EmailChecked: user.EmailChecked
            );
        }
    }
}
