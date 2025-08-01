using HotelBooking.Application.Dtos.Client;
using HotelBooking.Application.Interfaces.Services;
using HotelBooking.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : BaseController
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseView<ClientResponseDto>>> Create([FromBody] ClientRegisterDto clientCreate)
        {
            return Ok(new ResponseView<ClientResponseDto>(
                true,
                "Client created successfully.",
                await _clientService.Create(clientCreate)
                )
            );
        }

        [HttpGet("GetByPublicId/{id}")]
        public async Task<ActionResult<ResponseView<ClientResponseDto>>> GetByPublicId(string id)
        {
            return Ok(new ResponseView<ClientResponseDto>(
                true,
                "Client retrieved successfully.",
                await _clientService.GetByPublicId(id)
                )
            );
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ResponseView<IEnumerable<ClientResponseDto>>>> GetAll()
        {
            return Ok(new ResponseView<IEnumerable<ClientResponseDto>>(
                true,
                "Clients retrieved successfully.",
                await _clientService.GetAll()
                )
            );
        }

        [HttpGet("GetAllActives")]
        public async Task<ActionResult<ResponseView<IEnumerable<ClientResponseDto>>>> GetAllActives()
        {
            return Ok(new ResponseView<IEnumerable<ClientResponseDto>>(
                true,
                "Active clients retrieved successfully.",
                await _clientService.GetAllActive()
                )
            );
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ResponseView<ClientResponseDto>>> Update([FromBody] ClientUpdateDto clientUpdate)
        {
            return Ok(new ResponseView<ClientResponseDto>(
                true,
                "Client updated successfully.",
                await _clientService.Update(clientUpdate)
                )
            );
        }

        [HttpDelete]
        public async Task<ActionResult<ResponseView<bool>>> Delete([FromQuery] string clientId)
        {
            await _clientService.Delete(clientId);

            return Ok(new ResponseView<bool>(
                true,
                "Client deleted successfully."
                )
            );
        }
    }
}
