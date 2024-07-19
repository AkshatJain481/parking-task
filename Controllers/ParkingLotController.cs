using Microsoft.AspNetCore.Mvc;
using ParkingLotSystemBackend.Models;
using ParkingLotSystemBackend.Services;

namespace ParkingLotSystemBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParkingLotController : ControllerBase
{
    private readonly ParkingLotService _parkingLotService;

    public ParkingLotController(ParkingLotService parkingLotService)
    {
        _parkingLotService = parkingLotService;
    }

    [HttpPost("park")]
    public IActionResult ParkVehicle([FromBody] Vehicle vehicle)
    {
        var result = _parkingLotService.ParkVehicle(vehicle);
        return Ok(result);
    }

    [HttpPost("unpark")]
    public IActionResult UnparkVehicle([FromBody] string ticketId)
    {
        var result = _parkingLotService.UnparkVehicle(ticketId);
        return Ok(result);
    }

    [HttpGet("free-count/{vehicleType}")]
    public IActionResult DisplayFreeCount(string vehicleType)
    {
        var result = _parkingLotService.DisplayFreeCount(vehicleType);
        return Ok(result);
    }

    [HttpGet("free-slots/{vehicleType}")]
    public IActionResult DisplayFreeSlots(string vehicleType)
    {
        var result = _parkingLotService.DisplayFreeSlots(vehicleType);
        return Ok(result);
    }

    [HttpGet("occupied-slots/{vehicleType}")]
    public IActionResult DisplayOccupiedSlots(string vehicleType)
    {
        var result = _parkingLotService.DisplayOccupiedSlots(vehicleType);
        return Ok(result);
    }
}