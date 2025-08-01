using HotelBooking.Application.Dtos.Room;
using HotelBooking.Application.Interfaces.Services;
using HotelBooking.Application.Mappers;
using HotelBooking.Domain.Interfaces.Repositories;

namespace HotelBooking.Application.Services;

public class RoomService : IBaseService<RoomResponseDto, RoomRegisterDto, RoomUpdateDto>, IRoomService
{
    private readonly IRoomRepository  _roomRepository;
    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }
    public async Task<RoomResponseDto> GetByPublicId(string id)
    {
        var room = await _roomRepository.GetByPublicId(id);
        return room.ToResponse();
    }

    public async Task<IEnumerable<RoomResponseDto>> GetAll()
    {
        var rooms = await _roomRepository.GetAll();
        return rooms.Select(room => room.ToResponse());
    }

    public async Task<RoomResponseDto> Create(RoomRegisterDto registerDto)
    {
        var room = registerDto.ToEntity();
        room.GenerateIdsIfNeeded();

        await _roomRepository.Register(room);
        
        return room.ToResponse();
    }

    public async Task<RoomResponseDto> Update(RoomUpdateDto updateDto)
    {
        var room = await _roomRepository.GetByPublicId(updateDto.PublicId);
        if (room is null)
            throw new ArgumentException("Room not found.");

        room.ToUpdate();
        await _roomRepository.Update(room);

        return room.ToResponse();
    }

    public async Task Delete(string id)
    {
        await _roomRepository.Delete(id);
    }

    public async Task<List<RoomResponseDto>> GetAllRoomsAsync()
    {
        var rooms = await _roomRepository.GetAll();
        return rooms.Select(room => room.ToResponse()).ToList();
    }

    public async Task<List<RoomResponseDto>> GetAllRoomsActivatedAsync()
    {
        var rooms = await _roomRepository.GetAllRoomsActivatedAsync();
        return rooms.Select(room => room.ToResponse()).ToList();
    }

    public Task<List<RoomResponseDto>> GetRoomsByCapacityAsync(int capacity)
    {
        throw new NotImplementedException();
    }
}