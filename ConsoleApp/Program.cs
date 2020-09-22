using System;
using SharedLibraries.Models;
using Microsoft.Azure.Devices.Client;
using SharedLibraries.Services;

namespace ConsoleApp
{
    class Program
    {
        private static readonly string _conn = "HostName=Alex-win20-iothub.azure-devices.net;DeviceId=consoleapp;SharedAccessKey=Vx5YH1x8bEsBL0+jMGLHvgL2eJIwHNgsk2HmUNl2xjU=";
        
        private static readonly DeviceClient deviceClient = DeviceClient.CreateFromConnectionString(_conn, TransportType.Mqtt);
        static void Main(string[] args)
        {
            DeviceService.SendMessageAsync(deviceClient).GetAwaiter();
            DeviceService.ReceiveMessageAsync(deviceClient).GetAwaiter();

            Console.ReadKey();
        }
    }
}
