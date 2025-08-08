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
        public async Task<ActionResult<ResponseView<RoomResponseDto>>> Register([FromBody] RoomRegisterDto registerDto)
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

        [HttpGet("GetByPublicId/{publicId}")]
        public async Task<ActionResult<ResponseView<RoomResponseDto>>> GetByPublicId(string publicId)
        {
            return Ok(
                new ResponseView<RoomResponseDto>(
                    true,
                     "Room retrieved successfully",
                      await _roomService.GetByPublicId(publicId)
                )
            );
        }
        [HttpPatch]
        public async Task<ActionResult<ResponseView<RoomResponseDto>>> Update([FromBody] RoomUpdateDto updateDto)
        {
            return Ok(
                new ResponseView<RoomResponseDto>(
                    true,
                    "Room updated successfully",
                    await _roomService.Update(updateDto)
                )
            );
        }
        [HttpDelete("{publicId}")]
        public async Task<ActionResult<ResponseView<string>>> Delete(string publicId)
        {
            await _roomService.Delete(publicId);
            return Ok(
                new ResponseView<string>(
                    true,
                    "Room deleted successfully"
                )
            );
        }
    }
}
