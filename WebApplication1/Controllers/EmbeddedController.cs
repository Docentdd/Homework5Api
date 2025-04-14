// using Microsoft.AspNetCore.Mvc;
//
//
// namespace WebApplication1.Controllers;
// [Route("api/embdevice")]
// [ApiController]
// public class EmbeddedController : ControllerBase
// {
//     private static List<Embedded> _devices = new List<Embedded>
//     {
//         new Embedded 
//         { 
//             Id = 1, 
//             Name = "Device1", 
//             ipAdress = "192.168.1.1", 
//             isConnected = true, 
//             NetworkName = "Network1" 
//         },
//         new Embedded 
//         { 
//             Id = 2, 
//             Name = "Device2", 
//             ipAdress = "192.168.1.2", 
//             isConnected = false, 
//             NetworkName = "Network2" 
//         }
//
//     };
//     [HttpPost]
//     public IActionResult Post([FromBody] Embedded device)
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
//     public IActionResult EditDevice(int id, [FromBody] Embedded updatedDevice)
//     {
//         var device = _devices.FirstOrDefault(d => d.Id == id);
//         if (device == null)
//         {
//             return NotFound($"Device {id} not found");
//         }
//     
//         device.Name = updatedDevice.Name;
//         device.ipAdress = updatedDevice.ipAdress;
//         device.isConnected = updatedDevice.isConnected;
//         device.NetworkName = updatedDevice.NetworkName;
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
//         return Ok();
//     }
//     
// }