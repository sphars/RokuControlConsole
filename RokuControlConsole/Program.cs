using RokuControlConsole.Data;
using RokuControlConsole.Models;
using System;
using System.Threading.Tasks;

namespace RokuControlConsole
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.Title = "Roku Control Console";
            Console.WriteLine("Roku Control Console");

            RokuDataOperations dataOperations = RokuDataOperations.Instance();
            await dataOperations.LoadDevices();
            dataOperations.PrintSavedDevices();

            Console.WriteLine();
            Console.Write("Enter a Roku device IP address to control: ");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                // TODO: validate input IP address
                    
                RokuConfig.SetUrl(input);

                var response = await RokuClient.GetRokuInformation(new Uri(RokuConfig.BaseUrl + "query/device-info"));
                var rokuDeviceInfo = RokuDataOperations.DeserializeXMLToRokuDevice(response);
                rokuDeviceInfo.IPAddress = input;
                
                dataOperations.AddRokuDevice(rokuDeviceInfo.Udn, rokuDeviceInfo);
                await dataOperations.SaveDevices();

                Console.WriteLine($"Now controlling {rokuDeviceInfo.FriendlyDeviceName} ({rokuDeviceInfo.ModelName})");

                Console.WriteLine("Enter your input (escape to quit)");

                await GetInput();
            }
        }

        private static async Task GetInput()
        {
            Action work = () =>
            {
                do
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Escape)
                    {
                        RokuConfig.SetDone();
                    }
                    else if (!RokuConfig.IsValidKey(key.Key))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Invalid key: {key.Key}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        var command = RokuConfig.GetRokuCommand(key);
                        Console.WriteLine($"Input: {command.Key} | Command: {command.Name}");
                        Console.ResetColor();
                        RokuClient.SendRokuCommand(command);
                    }
                } while (!RokuConfig.IsDone);
            };

            await Task.Run(work);
        }
    }
}
