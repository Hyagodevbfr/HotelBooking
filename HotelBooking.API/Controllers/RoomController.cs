using HotelBooking.Application.Dtos.Room;
using HotelBooking.Application.Interfaces.Services;
using HotelBooking.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : BaseController
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ResponseView<RoomResponseDto>>> Register( [FromBody] RoomRegisterDto registerDto)
        {
            return Ok(
                new ResponseView<RoomResponseDto>(
                    true,
                    "Room Registered successfully",
                    await _roomService.Create(registerDto)
                )
            );
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<RoomResponseDto>>> GetAllRooms()
        {
            return Ok(
                new ResponseView<List<RoomResponseDto>>(
                    true,
                    "Rooms retrieved successfully",
                    await _roomService.GetAllRoomsAsync()
                )
            );
        }

        [HttpGet("GetAllActivated")]
        public async Task<ActionResult<List<RoomResponseDto>>> GetAllRoomsActivated()
        {
            return Ok(
                new ResponseView<List<RoomResponseDto>>(
                    true,
                    "Rooms retrieved successfully",
                    await _roomService.GetAllRoomsActivatedAsync()
                )
            );
        }
    }
}
