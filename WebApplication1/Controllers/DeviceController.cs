using Microsoft.AspNetCore.Mvc;
    
    namespace WebApplication1.Controllers;
    
    [Route("api/devices")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private static List<Smartwatch> _smartwatches = new List<Smartwatch>{
            new Smartwatch 
            { 
                Id = 1, 
                Name = "Device1", 
                IsEnabled = true, 
                BatteryLevel = 67
            },
            new Smartwatch 
            { 
                Id = 2, 
                Name = "Device2", 
                IsEnabled = false, 
                BatteryLevel =  34
            }
        };
        private static List<Embedded> _embeddedDevices = new List<Embedded>
        {
            new Embedded 
            { 
                Id = 1, 
                Name = "Device1", 
                IpAdress = "192.168.1.1", 
                IsConnected = true, 
                NetworkName = "Network1" 
            },
            new Embedded 
            { 
                Id = 2, 
                Name = "Device2", 
                IpAdress = "192.168.1.2", 
                IsConnected = false, 
                NetworkName = "Network2" 
            }

        };
        private static List<PersonalComputer> _personalComputers = new List<PersonalComputer>{
            new PersonalComputer
            {
                Id = 1,
                Name = "Device1",
                IsEnabled = true,
                OperatingSystem = "Windows 10"
            },
            new PersonalComputer
            {
                Id = 2,
                Name = "Device2",
                IsEnabled = false,
                OperatingSystem = "Linux"
            }
        };
    
        [HttpPost("smartwatch")]
        public IResult AddSmartwatch([FromBody] Smartwatch device)
        {
            _smartwatches.Add(device);
            return Results.CreatedAtRoute(nameof(GetSmartwatchById), new { id = device.Id }, device);
        }
    
        [HttpPost("embedded")]
        public IResult AddEmbeddedDevice([FromBody] Embedded device)
        {
            _embeddedDevices.Add(device);
            return Results.CreatedAtRoute(nameof(GetEmbeddedDeviceById), new { id = device.Id }, device);
        }
    
        [HttpPost("pc")]
        public IResult AddPersonalComputer([FromBody] PersonalComputer device)
        {
            _personalComputers.Add(device);
            return Results.CreatedAtRoute(nameof(GetPersonalComputerById), new { id = device.Id }, device);
        }
    
        [HttpGet("smartwatch")]
        public IResult GetAllSmartwatches()
        {
            return Results.Ok(_smartwatches);
        }
    
        [HttpGet("embedded")]
        public IResult GetAllEmbeddedDevices()
        {
            return Results.Ok(_embeddedDevices);
        }
    
        [HttpGet("pc")]
        public IResult GetAllPersonalComputers()
        {
            return Results.Ok(_personalComputers);
        }
    
        [HttpGet("smartwatch/{id}")]
        public IResult GetSmartwatchById(int id)
        {
            var device = _smartwatches.FirstOrDefault(d => d.Id == id);
            return device == null ? Results.NotFound($"Smartwatch {id} not found") : Results.Ok(device);
        }
    
        [HttpGet("embedded/{id}")]
        public IResult GetEmbeddedDeviceById(int id)
        {
            var device = _embeddedDevices.FirstOrDefault(d => d.Id == id);
            return device == null ? Results.NotFound($"Embedded device {id} not found") : Results.Ok(device);
        }
    
        [HttpGet("pc/{id}")]
        public IResult GetPersonalComputerById(int id)
        {
            var device = _personalComputers.FirstOrDefault(d => d.Id == id);
            return device == null ? Results.NotFound($"Personal computer {id} not found") : Results.Ok(device);
        }
    
        [HttpPut("smartwatch/{id}")]
        public IResult EditSmartwatch(int id, [FromBody] Smartwatch updatedDevice)
        {
            var device = _smartwatches.FirstOrDefault(d => d.Id == id);
            if (device == null) return Results.NotFound($"Smartwatch {id} not found");
    
            device.Name = updatedDevice.Name;
            device.IsEnabled = updatedDevice.IsEnabled;
            device.BatteryLevel = updatedDevice.BatteryLevel;
    
            return Results.NoContent();
        }
    
        [HttpPut("embedded/{id}")]
        public IResult EditEmbeddedDevice(int id, [FromBody] Embedded updatedDevice)
        {
            var device = _embeddedDevices.FirstOrDefault(d => d.Id == id);
            if (device == null) return Results.NotFound($"Embedded device {id} not found");
    
            device.Name = updatedDevice.Name;
            device.IpAdress = updatedDevice.IpAdress;
            device.IsConnected = updatedDevice.IsConnected;
            device.NetworkName = updatedDevice.NetworkName;
    
            return Results.NoContent();
        }
    
        [HttpPut("pc/{id}")]
        public IResult EditPersonalComputer(int id, [FromBody] PersonalComputer updatedDevice)
        {
            var device = _personalComputers.FirstOrDefault(d => d.Id == id);
            if (device == null) return Results.NotFound($"Personal computer {id} not found");
    
            device.Name = updatedDevice.Name;
            device.IsEnabled = updatedDevice.IsEnabled;
            device.OperatingSystem = updatedDevice.OperatingSystem;
    
            return Results.NoContent();
        }
    
        [HttpDelete("smartwatch/{id}")]
        public IResult DeleteSmartwatch(int id)
        {
            var device = _smartwatches.FirstOrDefault(d => d.Id == id);
            if (device == null) return Results.NotFound($"Smartwatch {id} not found");
    
            _smartwatches.Remove(device);
            return Results.NoContent();
        }
    
        [HttpDelete("embedded/{id}")]
        public IResult DeleteEmbeddedDevice(int id)
        {
            var device = _embeddedDevices.FirstOrDefault(d => d.Id == id);
            if (device == null) return Results.NotFound($"Embedded device {id} not found");
    
            _embeddedDevices.Remove(device);
            return Results.NoContent();
        }
    
        [HttpDelete("pc/{id}")]
        public IResult DeletePersonalComputer(int id)
        {
            var device = _personalComputers.FirstOrDefault(d => d.Id == id);
            if (device == null) return Results.NotFound($"Personal computer {id} not found");
    
            _personalComputers.Remove(device);
            return Results.NoContent();
        }
    }