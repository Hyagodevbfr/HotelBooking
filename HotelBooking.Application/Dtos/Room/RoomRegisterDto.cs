namespace HotelBooking.Application.Dtos.Room;

public record RoomRegisterDto(
    string Name,
    string Description,
    int Capacity,
    int Quantity,
    double PricePerNight,
    bool IsAvailable
    );