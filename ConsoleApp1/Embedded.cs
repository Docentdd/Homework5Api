using System.Text.RegularExpressions;
namespace WebApplication1.Controllers;

public class Embedded : Device
{
    public string ipAdress { get; set; }
    public bool isConnected { get; set; }
    public string NetworkName { get; set; }
}