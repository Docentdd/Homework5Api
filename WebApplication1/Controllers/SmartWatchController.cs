using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;


[Route("api/smdevice")]
[ApiController]
public class SmartWatchController : ControllerBase
{
    private static List<Smartwatch> _devices = new List<Smartwatch>
    {
        new Smartwatch 
        { 
            Id = 1, 
            Name = "Device1", 
            isEnabled = true, 
            batteryLevel = 67
        },
        new Smartwatch 
        { 
            Id = 2, 
            Name = "Device2", 
            isEnabled = false, 
            batteryLevel =  34
        }
    };

    [HttpPost]
    public IActionResult Post([FromBody] Smartwatch device)
    {
        _devices.Add(device);
        return CreatedAtAction("Post", device);
    }

    [HttpGet]
    public IActionResult GetAllDevices()
    {
        return Ok(_devices);
    }

    [HttpGet("{id}")]
    public IActionResult GetDeviceById(int id)
    {
        var device = _devices.FirstOrDefault(d => d.Id == id);
        if (device == null)
        {
            return NotFound();
        }
        return Ok(device);
    }

    [HttpPut("{id}")]
    public IActionResult EditDevice(int id, [FromBody] Smartwatch updatedDevice)
    {
        var device = _devices.FirstOrDefault(d => d.Id == id);
        if (device == null)
        {
            return NotFound($"Device {id} not found");
        }

        device.Name = updatedDevice.Name;
        device.isEnabled = updatedDevice.isEnabled;
        device.batteryLevel = updatedDevice.batteryLevel;

        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteDevice(int id)
    {
        var device = _devices.FirstOrDefault(d => d.Id == id);
        if (device == null)
        {
            return NotFound($"Device {id} not found");
        }

        _devices.Remove(device);
        return NoContent();
    }
    
}