using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Interfaces.Repositories;
using HotelBooking.SharedKernel.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HotelBooking.Infrastructure.Repositories;

public class RoomRepository : BaseRepository<Room>, IRoomRepository
{
    private readonly IMongoCollection<Room> _mongoContext;
    public RoomRepository(IOptions<MongoDbSettings> services) : base(services)
    {
        var mongoClient = new MongoClient(services.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(services.Value.DatabaseName);
        _mongoContext = mongoDatabase.GetCollection<Room>(typeof(Room).Name);
    }

    public async Task<List<Room>> GetAllRoomsAsync()
    {
        var result = await _mongoContext.FindAsync<Room>(Builders<Room>.Filter.Empty);
        
        return result.ToList();
    }

    public Task<List<Room>> GetAllRoomsActivatedAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<Room>> GetRoomsByCapacityAsync(int capacity)
    {
        throw new NotImplementedException();
    }
}