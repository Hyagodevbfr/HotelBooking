using HotelBooking.Application.Dtos.User;
using HotelBooking.Application.Interfaces.Services;
using HotelBooking.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        //[Authorize]
        public async Task<ActionResult<ResponseView<UserResponseDto>>> Register([FromBody] UserRegisterDto userRegister)
        {
            return Ok(new ResponseView<UserResponseDto>(
                true,
                "User registered successfully.",
                await _userService.Create(userRegister)
                )
            );
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<ResponseView<AuthResponse>>> Login([FromBody] UserLoginDto login)
        {
            return Ok(new ResponseView<AuthResponse>(
                true,
                "login successful.",
                await _userService.Login(login)
                )
            );
        }

        [HttpGet("GetByPublicId")]
        //[Authorize]
        public async Task<ActionResult<ResponseView<UserResponseDto>>> GetByPublicId(string publicId)
        {
            return Ok(new ResponseView<UserResponseDto>(
                true,
                "User retrieved successfully.",
                await _userService.GetByPublicId(publicId)
                )
            );
        }

        [HttpGet("GetByCpf")]
        //[Authorize]
        public async Task<ActionResult<ResponseView<UserResponseDto>>> GetByCpf(string cpf)
        {
            return Ok(new ResponseView<UserResponseDto>(
                true,
                "User retrieved successfully.",
                await _userService.GetByCpfAsync(cpf)
                )
            );
        }

        [HttpGet("GetByEmail")]
        //[Authorize]
        public async Task<ActionResult<ResponseView<UserResponseDto>>> GetByEmail(string email)
        {
            return Ok(new ResponseView<UserResponseDto>(
                true,
                "User retrieved successfully.",
                await _userService.GetByEmailAsync(email)
                )
            );
        }

        [HttpGet("GetAll")]
        //[Authorize]
        public async Task<ActionResult<ResponseView<IEnumerable<UserResponseDto>>>> GetAll()
        {
            return Ok(new ResponseView<IEnumerable<UserResponseDto>>(
                true,
                "Users retrieved successfully.",
                await _userService.GetAll()
                )
            );
        }

        [HttpGet("GetAllActive")]
        //[Authorize]
        public async Task<ActionResult<ResponseView<IEnumerable<UserResponseDto>>>> GetAllActive()
        {
            return Ok(new ResponseView<IEnumerable<UserResponseDto>>(
                true,
                "Active users retrieved successfully.",
                await _userService.GetAllActive()
                )
            );
        }

        [HttpPatch("Update")]
        //[Authorize]
        public async Task<ActionResult<ResponseView<UserResponseDto>>> Update([FromBody] UserUpdateDto userUpdate)
        {
            return Ok(new ResponseView<UserResponseDto>(
                true,
                "User updated successfully.",
                await _userService.Update(userUpdate)
                )
            );
        }
    }
}
