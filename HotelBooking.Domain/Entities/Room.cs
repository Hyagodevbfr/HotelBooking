namespace HotelBooking.Domain.Entities;

public class Room : BaseEntity
{
    public string? RoomName { get; set; }
    public string? Description { get; set; }
    public int Capacity { get; set; }
    public int Quantity { get; set; }
    public double PricePerNight { get; set; }
    public bool IsAvailable { get; set; }

    public Room() { }

    public Room(string? roomName, string? description, int capacity, int quantity, double pricePerNight, bool isAvailable)
    {
        RoomName = roomName;
        Description = description;
        Capacity = capacity;
        Quantity = quantity;
        PricePerNight = pricePerNight;
        IsAvailable = isAvailable;
    }

    public void Update(string? roomName, string? description, int capacity, int quantity, double pricePerNight, bool isAvailable)
    {
        RoomName = roomName;
        Description = description;
        Capacity = capacity;
        Quantity = quantity;
        PricePerNight = pricePerNight;
        IsAvailable = isAvailable;
    }

    public void DecreaseQuantity(int booking)
    {
        if (Quantity - booking < 0 || Quantity == 0)
            throw new InvalidOperationException("Not enough rooms available.");

        Quantity -= booking;

        if (Quantity == 0)
            IsAvailable = false;
    }


}