using HotelBooking.Application.Configurations;
using HotelBooking.Application.Dtos.User;
using HotelBooking.Application.Interfaces.Services;
using HotelBooking.Application.Mappers;
using HotelBooking.Application.ViewModels;
using HotelBooking.Domain.Interfaces.Repositories;
using System.Globalization;

namespace HotelBooking.Application.Services
{
    public class UserService : IBaseService<UserResponseDto, UserRegisterDto, UserUpdateDto>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IUserPasswordHasher _userPasswordHasher;
        private readonly TokenConfiguration _tokenConfiguration;

        public UserService(
         IUserRepository userRepository, ITokenService tokenService,
         TokenConfiguration tokenConfiguration, IUserPasswordHasher userPasswordHasher)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _tokenConfiguration = tokenConfiguration;
            _userPasswordHasher = userPasswordHasher;
        }

        public async Task<UserResponseDto> Create(UserRegisterDto registerDto)
        {
            var existingUserEmail = await _userRepository.GetByEmailAsync(registerDto.Email);
            var existingUserCpf = await _userRepository.GetByCpfAsync(registerDto.Cpf);

            if (existingUserEmail != null || existingUserCpf != null)
                throw new ArgumentException("User with this email or CPF already exists.");

            var passwordHashed = _userPasswordHasher.HashPassword(registerDto.Password);
            


            var user = registerDto.ToEntity(passwordHashed);
            user.GenerateIdsIfNeeded();

            await _userRepository.Register(user);

            return user.ToResponse();

        }

        public async Task Delete(string publicId)
        {
            await _userRepository.Delete(publicId);
        }

        public async Task<IEnumerable<UserResponseDto>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return users.Select(user => user.ToResponse()).ToList();
        }

        public async Task<UserResponseDto> GetByPublicId(string id)
        {
            var user = await _userRepository.GetByPublicId(id);
            return user.ToResponse();
        }

        public async Task<UserResponseDto> Update(UserUpdateDto updateDto)
        {
            var user = await _userRepository.GetByPublicId(updateDto.PublicId!);
            if (user is null)
                throw new ArgumentException("User not found.");

            user.ToUpdate();
            await _userRepository.Update(user);

            return user.ToResponse();
        }

        public async Task<UserResponseDto> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user is null)
                throw new ArgumentException("User not found.");

            return user.ToResponse();
        }

        public async Task<UserResponseDto> GetByCpfAsync(string cpf)
        {
            var user = await _userRepository.GetByCpfAsync(cpf);
            if (user is null)
                throw new ArgumentException("User not found.");

            return user.ToResponse();
        }

        public async Task<AuthResponse> Login(UserLoginDto userLogin)
        {
            var userDb = await _userRepository.GetByEmailAsync(userLogin.Email);

            if (userDb is null)
                throw new ArgumentException("User not found.");

            var passwordMatches = _userPasswordHasher.VerifyPassword(userDb.PasswordHash, userLogin.Password);

            if (!passwordMatches)
                throw new ArgumentException("Invalid password.");

            var userToken = _tokenService.GenerateToken(userDb);

            return new AuthResponse(
                userToken,
                true,
                "Login successful.",
                DateTime.Now.AddDays(_tokenConfiguration.TimeToExpiry).ToString(CultureInfo.InvariantCulture)
                );
        }

        public async Task<UserResponseDto> Inactive(string publicId)
        {
            var user = await _userRepository.GetByPublicId(publicId);
            if (user is null)
                throw new ArgumentException("User not found.");

            var inactivatedUser = _userRepository.Inactive(user);

            return inactivatedUser.Result.ToResponse();
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllActive()
        {
            var users = await _userRepository.GetAllActive();
            return users.Select(user => user.ToResponse()).ToList();
        }

        // Client methods

        public async Task<IEnumerable<UserResponseDto>> GetAllClients()
        {
            var clients = await _userRepository.GetAllClients();
            return clients.Select(client => client.ToResponse()).ToList();
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllActivatedClients()
        {
            var clients = await _userRepository.GetAllActivatedClients();
            return clients.Select(client => client.ToResponse()).ToList();
        }
    }
}
