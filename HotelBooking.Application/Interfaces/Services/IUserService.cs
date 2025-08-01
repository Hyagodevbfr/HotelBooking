using HotelBooking.Application.Dtos.User;
using HotelBooking.Application.ViewModels;

namespace HotelBooking.Application.Interfaces.Services
{
    public interface IUserService : IBaseService<UserResponseDto, UserRegisterDto, UserUpdateDto>
    {
        Task<UserResponseDto> GetByEmailAsync(string email);
        Task<UserResponseDto> GetByCpfAsync(string cpf);
        Task<IEnumerable<UserResponseDto>> GetAllActive();
        Task<AuthResponse> Login(UserLoginDto userLogin);
        Task<UserResponseDto> Inactive(string publicId);

        // Client methods
        Task<IEnumerable<UserResponseDto>> GetAllClients();
        Task<IEnumerable<UserResponseDto>> GetAllActivatedClients();
    }
}
