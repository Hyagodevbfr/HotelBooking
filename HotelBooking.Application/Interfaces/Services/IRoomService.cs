using HotelBooking.Application.Dtos.Room;

namespace HotelBooking.Application.Interfaces.Services;

public interface IRoomService : IBaseService<RoomResponseDto, RoomRegisterDto, RoomUpdateDto>
{
    Task<List<RoomResponseDto>> GetAllRoomsAsync();
    Task<List<RoomResponseDto>> GetAllRoomsActivatedAsync();
}