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
        _mongoContext = mongoDatabase.GetCollection<Room>(nameof(Room));
    }

    public async Task<List<Room>> GetAllRoomsAsync()
    {
        var result = await _mongoContext.FindAsync<Room>(Builders<Room>.Filter.Empty);
        
        return result.ToList();
    }

    public async Task<List<Room>> GetAllRoomsActivatedAsync()
    {
        var filter = Builders<Room>.Filter.Eq(room => room.IsAvailable, true);
        
        var result = await _mongoContext.FindAsync<Room>(filter);
        
        return result.ToList();
    }
}