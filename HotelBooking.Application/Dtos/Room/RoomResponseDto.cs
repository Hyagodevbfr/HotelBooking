namespace HotelBooking.Application.Dtos.Room;

public record RoomResponseDto(
    string PublicId,
    string Name,
    int Capacity,
    double PricePerNight,
    bool IsAvailable
    );