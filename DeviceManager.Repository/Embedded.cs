using System.Text.RegularExpressions;
namespace WebApplication1.Controllers;

public class Embedded : Device
{
    public string IpAdress { get; set; }
    public bool IsConnected { get; set; }
    public string NetworkName { get; set; }
}