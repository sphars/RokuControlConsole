using RokuControlConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RokuControlConsole.Data
{
    public static class RokuConfig
    {
        private static readonly string port = "8060";
        public static string BaseUrl { get; private set; }
        public static bool IsDone { get; private set; }


        private static readonly List<RokuCommand> RokuCommands = new()
        {
            new RokuCommand
            {
                Name = "Home",
                Path = "keypress/Home",
                Key = ConsoleKey.H
            },
            new RokuCommand
            {
                Name = "Back",
                Path = "keypress/Back",
                Key = ConsoleKey.Backspace
            },
            new RokuCommand
            {
                Name = "Up",
                Path = "keypress/Up",
                Key = ConsoleKey.UpArrow
            },
            new RokuCommand
            {
                Name = "Down",
                Path = "keypress/Down",
                Key = ConsoleKey.DownArrow
            },
            new RokuCommand
            {
                Name = "Left",
                Path = "keypress/Left",
                Key = ConsoleKey.LeftArrow
            },
            new RokuCommand
            {
                Name = "Right",
                Path = "keypress/Right",
                Key = ConsoleKey.RightArrow
            },
            new RokuCommand
            {
                Name = "Select",
                Path = "keypress/Select",
                Key = ConsoleKey.Enter
            },
            new RokuCommand
            {
                Name = "Play/Pause",
                Path = "keypress/Play",
                Key = ConsoleKey.Spacebar
            },
            new RokuCommand
            {
                Name = "Info",
                Path = "keypress/Info",
                Key = ConsoleKey.I
            },
            new RokuCommand
            {
                Name = "Reverse",
                Path = "keypress/Rev",
                Key = ConsoleKey.Z
            },
            new RokuCommand
            {
                Name = "Forward",
                Path = "keypress/Fwd",
                Key = ConsoleKey.X
            },
            new RokuCommand
            {
                Name = "Replay",
                Path = "keypress/InstantReplay",
                Key = ConsoleKey.C
            },
            new RokuCommand
            {
                Name = "Volume Up",
                Path = "keypress/VolumeUp",
                Key = ConsoleKey.OemPeriod
            },
            new RokuCommand
            {
                Name = "Volume Down",
                Path = "keypress/VolumeDown",
                Key = ConsoleKey.OemComma
            },
            new RokuCommand
            {
                Name = "Mute",
                Path = "keypress/VolumeMute",
                Key = ConsoleKey.M
            }
        };

        public static void SetUrl(string ipAddress) => BaseUrl = $"http://{ipAddress}:{port}/";

        public static bool IsValidKey(ConsoleKey consoleKey)
        {
            bool isValidKey = RokuCommands.Any(c => c.Key == consoleKey);
            return isValidKey;
        }

        public static RokuCommand GetRokuCommand(ConsoleKeyInfo consoleKey)
        {
            return RokuCommands.FirstOrDefault(c => c.Key == consoleKey.Key);
        }

        public static void SetDone() => IsDone = true;
    }
}
