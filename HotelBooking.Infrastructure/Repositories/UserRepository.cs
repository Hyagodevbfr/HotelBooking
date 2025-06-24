using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Interfaces.Repositories;
using HotelBooking.SharedKernel.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HotelBooking.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        protected readonly IMongoCollection<User> _mongoContext;
        public UserRepository(IOptions<MongoDbSettings> userService) : base(userService)
        {
            var mongoClient = new MongoClient(userService.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(userService.Value.DatabaseName);
            _mongoContext = mongoDatabase.GetCollection<User>(typeof(User).Name);
        }

        public async Task<IEnumerable<User>> GetAllActive()
        {
            var filter = Builders<User>.Filter.Eq(u => u.IsActive, true);
            var users = await _mongoContext.Find(filter).ToListAsync();

            return users;
        }

        public Task<User> GetByCpfAsync(string cpf)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Cpf, cpf);
            var user = _mongoContext.Find(filter).FirstOrDefaultAsync();

            return user;
        }

        public Task<User> GetByEmailAsync(string email)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Email, email);
            var user = _mongoContext.Find(filter).FirstOrDefaultAsync();

            return user;
        }

        public async Task<User> Inactive(User user)
        {
            user.Inactive();

            await Update(user);

            return user;
        }
    }
}
