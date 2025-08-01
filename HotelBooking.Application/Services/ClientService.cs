using HotelBooking.Application.Dtos.Client;
using HotelBooking.Application.Interfaces.Services;

namespace HotelBooking.Application.Services;

public class ClientService : IClientService
{
    private readonly IUserService _userService;

    public ClientService(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<ClientResponseDto> Create(ClientRegisterDto registerDto)
    {
        var client = await _userService.Create(registerDto.ToUserRegisterDto());
        return client.ToResponse();
    }

    public async Task Delete(string id)
    {
        await _userService.Delete(id);
    }

    public async Task<IEnumerable<ClientResponseDto>> GetAll()
    {
        var clients = await _userService.GetAllClients();
        return clients.Select(client => client.ToResponse()).ToList();
    }

    public async Task<IEnumerable<ClientResponseDto>> GetAllActive()
    {
        var activeClients = await _userService.GetAllActivatedClients();
        return activeClients.Select(client => client.ToResponse()).ToList();
    }

    public async Task<ClientResponseDto> GetByPublicId(string id)
    {
        var client = await _userService.GetByPublicId(id);
        return client.ToResponse();
    }

    public async Task<ClientResponseDto> Update(ClientUpdateDto updateDto)
    {
        var client = await _userService.Update(updateDto.ToUserUpdateDto());
        
        return client.ToResponse();
    }
}
