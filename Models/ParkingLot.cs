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
        
        // Calculate the number of slots for each vehicle type
        int slotsPerType = SlotsPerFloor / 3;
        int remainingSlots = SlotsPerFloor % 3;

        int truckSlots = slotsPerType;
        int bikeSlots = slotsPerType;
        int carSlots = slotsPerType + remainingSlots;

        int currentSlot = 0;

        // Add truck slots
        for (int i = 0; i < truckSlots; i++, currentSlot++)
        {
            floorSlots.Add(new ParkingSlot
            {
                FloorNumber = floor + 1,
                SlotNumber = currentSlot + 1,
                VehicleType = "TRUCK",
                IsOccupied = false
            });
        }

        // Add bike slots
        for (int i = 0; i < bikeSlots; i++, currentSlot++)
        {
            floorSlots.Add(new ParkingSlot
            {
                FloorNumber = floor + 1,
                SlotNumber = currentSlot + 1,
                VehicleType = "BIKE",
                IsOccupied = false
            });
        }

        // Add car slots
        for (int i = 0; i < carSlots; i++, currentSlot++)
        {
            floorSlots.Add(new ParkingSlot
            {
                FloorNumber = floor + 1,
                SlotNumber = currentSlot + 1,
                VehicleType = "CAR",
                IsOccupied = false
            });
        }

        floors.Add(floorSlots);
    }

    return floors;
}

}