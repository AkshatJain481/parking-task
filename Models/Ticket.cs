namespace ParkingLotSystemBackend.Models;

public class Ticket
{
    public required string Id { get; set; }
    public required int FloorNumber { get; set; }
    public required int SlotNumber { get; set; }
}