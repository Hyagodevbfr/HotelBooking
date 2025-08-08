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
            Description: room.Description,
            Capacity: room.Capacity,
            Quantity: room.Quantity,
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
            response.Quantity,
            response.PricePerNight,
            response.IsAvailable
        );
    }

    public static RoomUpdateDto ToEntity(this Room room)
    {
        return new RoomUpdateDto(
            room.PublicId.ToString(),
            room.RoomName,
            room.Description,
            room.Capacity,
            room.Quantity,
            room.PricePerNight,
            room.IsAvailable
        );
    }
}