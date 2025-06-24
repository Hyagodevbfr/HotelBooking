using HotelBooking.Domain.Entities;

namespace HotelBooking.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByCpfAsync(string cpf);
        Task<IEnumerable<User>> GetAllActive();
        Task<User> Inactive(User user);
    }
}
