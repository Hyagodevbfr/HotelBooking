using HotelBooking.Domain.Entities;

namespace HotelBooking.Domain.Interfaces.Repositories;

public interface IRoomRepository : IBaseRepository<Room>
{
    Task<List<Room>> GetAllRoomsAsync();
    Task<List<Room>> GetAllRoomsActivatedAsync();
    Task<List<Room>> GetRoomsByCapacityAsync(int capacity);
}