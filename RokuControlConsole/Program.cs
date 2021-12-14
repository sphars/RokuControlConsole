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
            Console.Write("Enter your Roku device's IP address: ");
            string input = Console.ReadLine();

            // TODO: validate IP address
            if (!string.IsNullOrWhiteSpace(input))
            {
                RokuConfig.SetUrl(input);

                var response = await RokuClient.GetRokuInformation(new Uri(RokuConfig.BaseUrl + "query/device-info"));
                var rokuDeviceInfo = RokuDataOperations.DeserializeXMLToRokuDevice(response);

                Console.WriteLine(rokuDeviceInfo.FriendlyDeviceName);

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
                        Console.WriteLine($"Valid key: {command.Key} - {command.Name}");
                        Console.ResetColor();
                        RokuDataOperations.SendRokuCommand(command);
                    }
                } while (!RokuConfig.IsDone);
            };

            await Task.Run(work);
        }
    }
}
