namespace HotelBooking.Application.Dtos.Room;

public record RoomResponseDto(
    string PublicId,
    string Name,
    string Description,
    int Capacity,
    int Quantity,
    double PricePerNight,
    bool IsAvailable
    );