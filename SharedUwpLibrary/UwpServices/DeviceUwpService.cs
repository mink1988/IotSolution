using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using SharedUwpLibrary.UwpModels;
using Uwp = Microsoft.Azure.Devices;


namespace SharedUwpLibrary.UwpServices
{
    public static class DeviceUwpService
    {
        private static readonly Random rnd = new Random();

        public static async Task SendMessageAsync(DeviceClient deviceClient)
        {
            while (true)
            {
                var data = new TemperatureUwpModel
                {
                    Temperature = rnd.Next(20, 30),
                    Humidity = rnd.Next(40, 50)
                };

                var json = JsonConvert.SerializeObject(data);

                var payload = new Message(Encoding.UTF8.GetBytes(json));
                await deviceClient.SendEventAsync(payload);


                Console.WriteLine($"Message sent: {json}");
                await Task.Delay(10 * 1000);

            }

        }

        public static async Task ReceiveMessageAsync(DeviceClient deviceClient)
        {
            while (true)
            {
                var payload = await deviceClient.ReceiveAsync();

                if (payload == null)
                    continue;

                Console.WriteLine($"Message Recieved: {Encoding.UTF8.GetString(payload.GetBytes())}");

                await deviceClient.CompleteAsync(payload);

            }
        }

        public static async Task SendMessageToDeviceAsync(Uwp.ServiceClient serviceClient, string targetDeviceId, string message)
        {
            var payload = new Uwp.Message(Encoding.UTF8.GetBytes(message));
            await serviceClient.SendAsync(targetDeviceId, payload);
        }

    }
}
