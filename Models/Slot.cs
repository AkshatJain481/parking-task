using ParkingLotSystemBackend.Models;

namespace ParkingLotSystemBackend.Models;

public class Slot
{
    public int FloorNumber { get; init; }
    public int SlotNumber { get; init; }
    public required string VehicleType { get; init; }
    public bool IsOccupied { get; set; }
    public Vehicle? ParkedVehicle { get; set; }
}