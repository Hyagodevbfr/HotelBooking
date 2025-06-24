namespace HotelBooking.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        public Task<T> GetByPublicId(string id);
        public Task<T> Register(T item);
        public Task<T> Update(T item);
        public Task<IEnumerable<T>> GetAll();
        public Task Delete(string publicId);
    }
}
