namespace HotelBooking.Domain.Entities;

public class Room : BaseEntity
{
    public string? RoomName { get; set; }
    public string? Description { get; set; }
    public int Capacity { get; set; }
    public double PricePerNight { get; set; }
    public bool IsAvailable { get; set; }

    public Room(){}
    
    public Room(string? roomName, string? description, int capacity, double pricePerNight, bool isAvailable)
    {
        RoomName = roomName;
        Description = description;
        Capacity = capacity;
        PricePerNight = pricePerNight;
        IsAvailable = isAvailable;
    }
}