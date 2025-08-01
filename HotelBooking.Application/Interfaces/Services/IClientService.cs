using HotelBooking.Application.Dtos.Client;
using HotelBooking.Application.Interfaces.Services;

namespace HotelBooking.Application.Interfaces.Services;

public interface IClientService : IBaseService<ClientResponseDto, ClientRegisterDto, ClientUpdateDto>
{
    Task<IEnumerable<ClientResponseDto>> GetAllActive();
}
