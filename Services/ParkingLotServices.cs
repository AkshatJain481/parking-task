using ParkingLotSystemBackend.Models;

namespace ParkingLotSystemBackend.Services;

public class ParkingLotService
{
    private readonly ParkingLot _parkingLot;

    public ParkingLotService()
    {
        _parkingLot = new ParkingLot("PR1234", 3, 9);
    }

    public string ParkVehicle(Vehicle vehicle)
    {
        foreach (var floor in _parkingLot.Floors)
        {
            foreach (var slot in floor)
            {
                if (!slot.IsOccupied && slot.VehicleType == vehicle.Type)
                {
                    slot.IsOccupied = true;
                    slot.ParkedVehicle = vehicle;
                    return $"{_parkingLot.Id}_{slot.FloorNumber}_{slot.SlotNumber}";
                }
            }
        }
        return "Parking Lot Full";
    }

    public string UnparkVehicle(string ticketId)
    {
        var ticketParts = ticketId.Split('_');
        if (ticketParts.Length != 3)
            return "Invalid Ticket";

        if (!int.TryParse(ticketParts[1], out int floor) || !int.TryParse(ticketParts[2], out int slot))
            return "Invalid Ticket";

        floor--; // Convert to 0-based index
        slot--;

        if (floor < 0 || floor >= _parkingLot.NumberOfFloors || slot < 0 || slot >= _parkingLot.SlotsPerFloor)
            return "Invalid Ticket";

        var parkingSlot = _parkingLot.Floors[floor][slot];
        if (!parkingSlot.IsOccupied)
            return "Invalid Ticket";

        var vehicle = parkingSlot.ParkedVehicle!;
        parkingSlot.IsOccupied = false;
        parkingSlot.ParkedVehicle = null;

        return $"Unparked vehicle with Registration Number: {vehicle.RegistrationNumber} and Color: {vehicle.Color}";
    }

    public IEnumerable<string> DisplayFreeCount(string vehicleType)
    {
        return _parkingLot.Floors.Select((floor, index) =>
            $"No. of free slots for {vehicleType} on Floor {index + 1}: {floor.Count(s => !s.IsOccupied && s.VehicleType == vehicleType)}");
    }

    public IEnumerable<string> DisplayFreeSlots(string vehicleType)
    {
        return _parkingLot.Floors.Select((floor, index) =>
            $"Free slots for {vehicleType} on Floor {index + 1}: {string.Join(", ", floor.Where(s => !s.IsOccupied && s.VehicleType == vehicleType).Select(s => s.SlotNumber))}");
    }

    public IEnumerable<string> DisplayOccupiedSlots(string vehicleType)
    {
        return _parkingLot.Floors.Select((floor, index) =>
            $"Occupied slots for {vehicleType} on Floor {index + 1}: {string.Join(", ", floor.Where(s => s.IsOccupied && s.VehicleType == vehicleType).Select(s => s.SlotNumber))}");
    }
}