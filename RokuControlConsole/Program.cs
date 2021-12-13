using System;
using System.Threading.Tasks;

namespace RokuControlConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Roku Control Console";
            Console.WriteLine("Roku Control Console");
            Console.Write("Enter your Roku device's IP address: ");
            string input = Console.ReadLine();

            // TODO: validate IP address
            if (!string.IsNullOrWhiteSpace(input))
            {
                RokuConfig.SetUrl(input);

                var info = await RokuClient.GetRokuInformation(new Uri(RokuConfig.baseUrl + "query/device-info"));

                Console.WriteLine(info);

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
                        SendRokuCommand(command);
                    }
                } while (!RokuConfig.IsDone);
            };
            await Task.Run(work);
        }

        private static void SendRokuCommand(RokuCommand command)
        {

            Uri url = new Uri(RokuConfig.baseUrl + command.Path);

            var t = Task.Run(() => RokuClient.PostCommand(url, ""));
            t.Wait();

            Console.WriteLine(t.Result);
        }
    }
}
