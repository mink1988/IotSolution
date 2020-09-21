using System;
using SharedLibraries.Models;
using Microsoft.Azure.Devices.Client;
using SharedLibraries.Services;

namespace ConsoleApp
{
    class Program
    {
        private static readonly string _conn = "";
        private static readonly DeviceClient deviceClient = DeviceClient.CreateFromConnectionString("", TransportType.Mqtt);
        static void Main(string[] args)
        {
            DeviceService.SendMessageAsync(deviceClient).GetAwaiter();
        }
    }
}
