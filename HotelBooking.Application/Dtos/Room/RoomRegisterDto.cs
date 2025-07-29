namespace HotelBooking.Application.Dtos.Room;

public record RoomRegisterDto(
    string Name,
    string Description,
    int Capacity,
    double PricePerNight,
    bool IsAvailable
    );