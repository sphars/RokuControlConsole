using System;
using System.Threading.Tasks;

namespace RokuControlConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Roku Control Console";
            Console.Write("Enter your Roku device's IP address: ");
            string input = Console.ReadLine();

            // TODO: validate IP address
            if (!string.IsNullOrWhiteSpace(input))
            {
                RokuConfig.SetUrl(input);

                Console.WriteLine("Enter your input (x to quit)");

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
                    if (key.Key == ConsoleKey.X)
                    {
                        RokuConfig.SetDone();
                    }
                    else if (!RokuConfig.IsValidKey(key.Key))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"invalid key: {key.Key}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"valid key: {key.Key}");
                        Console.ResetColor();
                        SendRokuCommand(key.Key);
                    }
                } while (!RokuConfig.IsDone);
            };
            await Task.Run(work);
        }

        private static void SendRokuCommand(ConsoleKey key)
        {
            var path = "";
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    path = "keypress/Up";
                    break;
                case ConsoleKey.DownArrow:
                    path = "keypress/Down";
                    break;
                case ConsoleKey.LeftArrow:
                    path = "keypress/Left";
                    break;
                case ConsoleKey.RightArrow:
                    path = "keypress/Right";
                    break;
                case ConsoleKey.Enter:
                    path = "keypress/Select";
                    break;
                case ConsoleKey.Spacebar:
                    path = "keypress/Play";
                    break;
                case ConsoleKey.Backspace:
                    path = "keypress/Back";
                    break;
                case ConsoleKey.OemPeriod:
                    path = "keypress/VolumeUp";
                    break;
                case ConsoleKey.OemComma:
                    path = "keypress/VolumeDown";
                    break;
                //case ConsoleKey.M:
                    //path = "keypress/Mute";
                    //break;
            }

            Uri url = new Uri(RokuConfig.baseUrl + path);

            var t = Task.Run(() => RokuClient.PostCommand(url, ""));
            t.Wait();

            Console.WriteLine(t.Result);
        }
    }
}
