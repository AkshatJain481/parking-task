namespace ParkingLotSystemBackend.Models;

public class ParkingLot
{
    public string Id { get; init; }
    public int NumberOfFloors { get; init; }
    public int SlotsPerFloor { get; init; }
    public List<List<ParkingSlot>> Floors { get; init; }

    public ParkingLot(string id, int numberOfFloors, int slotsPerFloor)
    {
        Id = id;
        NumberOfFloors = numberOfFloors;
        SlotsPerFloor = slotsPerFloor;
        Floors = InitializeFloors();
    }

    private List<List<ParkingSlot>> InitializeFloors()
    {
        var floors = new List<List<ParkingSlot>>();

        for (int floor = 0; floor < NumberOfFloors; floor++)
        {
            var floorSlots = new List<ParkingSlot>();
            for (int slot = 0; slot < SlotsPerFloor; slot++)
            {
                string vehicleType = slot == 0 ? "TRUCK" : (slot <= 2 ? "BIKE" : "CAR");
                floorSlots.Add(new ParkingSlot
                {
                    FloorNumber = floor + 1,
                    SlotNumber = slot + 1,
                    VehicleType = vehicleType,
                    IsOccupied = false
                });
            }
            floors.Add(floorSlots);
        }

        return floors;
    }
}