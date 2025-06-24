namespace HotelBooking.Application.Interfaces.Services
{
    public interface IBaseService<TResponseDto, TRegisterDto, TUpdateDto>
    {
        Task<TResponseDto> GetByPublicId(string id);
        Task<IEnumerable<TResponseDto>> GetAll();
        Task<TResponseDto> Create(TRegisterDto registerDto);
        Task<TResponseDto> Update(TUpdateDto updateDto);
        Task Delete(string id);

    }
}
