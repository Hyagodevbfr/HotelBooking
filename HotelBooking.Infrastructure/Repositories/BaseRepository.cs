using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Interfaces.Repositories;
using HotelBooking.SharedKernel.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HotelBooking.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>, IDisposable where T : BaseEntity, new()
    {
        private bool _disposedValue;
        private readonly IMongoCollection<T> _mongoContext;

        public BaseRepository(IOptions<MongoDbSettings> services)
        {
            _disposedValue = false;
            var mongoClient = new MongoClient(services.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(services.Value.DatabaseName);

            _mongoContext = mongoDatabase.GetCollection<T>(typeof(T).Name);
        }

        public virtual async Task Delete(string publicId)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq(e => e.PublicId, publicId);

                await _mongoContext.DeleteOneAsync(filter);
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while deleting the item with public ID {publicId}: {e.Message}", e);
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try 
            {
                var result = await _mongoContext.Find(_ => true).ToListAsync();

                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while retrieving all items: {e.Message}", e);
            }
        }

        public virtual async Task<T> GetByPublicId(string publicId)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq(e => e.PublicId, publicId);

                var result = await _mongoContext.Find(filter).FirstOrDefaultAsync();

                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while retrieving the item by public ID: {e.Message}", e);
            }
        }

        public virtual async Task<T> Register(T item)
        {
            try
            {
                if (item is null)
                    throw new ArgumentNullException(nameof(item), "Item cannot be null.");

                if(_mongoContext is null)
                    throw new InvalidOperationException("Mongo context is not initialized.");

                await _mongoContext.InsertOneAsync(item);
                return item;
            }
            catch(Exception e)
            {
                throw new Exception($"An error occurred while registering the item: {e.Message}", e);
            }
        }

        public async Task<T> Update(T item)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq(e => e.PublicId, item.PublicId);

                var updateDefinition = new List<UpdateDefinition<T>>();

                foreach (var property in typeof(T).GetProperties())
                {
                    var newValue = property.GetValue(item);

                    if (newValue is not null && !(newValue is ValueType && newValue.Equals(0)) && !((newValue is DateTime dt && dt == DateTime.MinValue) || (newValue is TimeSpan ts && ts == TimeSpan.MinValue)))
                    {
                        updateDefinition.Add(Builders<T>.Update.Set(property.Name, newValue));
                    }
                }

                if (!updateDefinition.Any())
                    return item;

                var combinedUpdate = Builders<T>.Update.Combine(updateDefinition);

                await _mongoContext.UpdateOneAsync(filter, combinedUpdate);

                return item;

            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while updating the item: {e.Message}", e);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~BaseRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
