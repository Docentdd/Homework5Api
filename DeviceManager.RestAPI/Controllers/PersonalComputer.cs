// using Microsoft.AspNetCore.Mvc;
//
// namespace DeviceManager.RestAPI.Controllers;
//
// [Route("api/pcdevice")]
// [ApiController]
// public class PersonalComputerController : ControllerBase
// {
//     public List<PersonalComputer> _devices = new List<PersonalComputer>
//     {
//         new PersonalComputer
//         {
//             Id = 1,
//             Name = "Device1",
//             isEnabled = true,
//             OperatingSystem = "Windows 10"
//         },
//         new PersonalComputer
//         {
//             Id = 2,
//             Name = "Device2",
//             isEnabled = false,
//             OperatingSystem = "Linux"
//         }
//     };
//     [HttpPost]
//     public IActionResult Post([FromBody] PersonalComputer device)
//     {
//         _devices.Add(device);
//         return CreatedAtAction("Post", device);
//     }
//     [HttpGet]
//     public IActionResult GetAllDevices()
//     {
//         return Ok(_devices);
//     }
//     [HttpGet("{id}")]
//     public IActionResult GetDeviceById(int id)
//     {
//         var device = _devices.FirstOrDefault(d => d.Id == id);
//         if (device == null)
//         {
//             return NotFound();
//         }
//         return Ok(device);
//     }
//     [HttpPut("{id}")]
//     public IActionResult EditDevice(int id, [FromBody] PersonalComputer updatedDevice)
//     {
//         var device = _devices.FirstOrDefault(d => d.Id == id);
//         if (device == null)
//         {
//             return NotFound($"Device {id} not found");
//         }
//
//         device.Name = updatedDevice.Name;
//         device.OperatingSystem = updatedDevice.OperatingSystem;
//         device.isEnabled = updatedDevice.isEnabled;
//
//         return Ok(device);
//     }
//     [HttpDelete("{id}")]
//     public IActionResult DeleteDevice(int id)
//     {
//         var device = _devices.FirstOrDefault(d => d.Id == id);
//         if (device == null)
//         {
//             return NotFound($"Device {id} not found");
//         }
//
//         _devices.Remove(device);
//         return NoContent();
//     }
// }