namespace ParkingLotSystemBackend.Models;

public class Floor
{
    public int FloorNumber { get; set; }
    public required List<Slot> Slots { get; set; }
}
