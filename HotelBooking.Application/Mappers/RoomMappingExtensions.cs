using HotelBooking.Application.Dtos.Room;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Mappers;

public static class RoomMappingExtensions
{
    public static RoomResponseDto ToResponse(this Room room)
    {
        return new RoomResponseDto(
            PublicId:  room.PublicId,
            Name: room.RoomName,
            Capacity: room.Capacity,
            PricePerNight: room.PricePerNight,
            IsAvailable: room.IsAvailable
        );
    }

    public static Room ToEntity(this RoomRegisterDto response)
    {
        return new Room(
            response.Name,
            response.Description,
            response.Capacity,
            response.PricePerNight,
            response.IsAvailable
        );
    }

    public static RoomUpdateDto ToUpdate(this Room room)
    {
        return new RoomUpdateDto(
            room.PublicId.ToString(),
            room.RoomName,
            room.Description,
            room.Capacity,
            room.PricePerNight,
            room.IsAvailable
        );
    }
}