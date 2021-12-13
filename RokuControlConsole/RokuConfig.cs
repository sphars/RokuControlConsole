using System;
using System.Collections.Generic;

namespace RokuControlConsole
{
    public static class RokuConfig
    {
        public static string baseUrl { get; private set; }
        private static string port = "8060";

        public static bool IsDone { get; private set; }

        private static List<ConsoleKey> validKeys = new List<ConsoleKey>
        {
            ConsoleKey.UpArrow, //dpad up
            ConsoleKey.DownArrow, //dpad down
            ConsoleKey.LeftArrow, //dpad left
            ConsoleKey.RightArrow, //dpad right
            ConsoleKey.Enter, //ok button
            ConsoleKey.Spacebar, //play button
            ConsoleKey.Backspace, //back button
            ConsoleKey.OemPeriod, //volume up
            ConsoleKey.OemComma, //volume down
            ConsoleKey.M, //mute
            ConsoleKey.H, //home button
            ConsoleKey.I, //info (*) button
            ConsoleKey.Z, //reverse
            ConsoleKey.X, //forward
            ConsoleKey.C //replay
        };

        public static void SetUrl(string ipAddress) => baseUrl = $"http://{ipAddress}:{port}/";

        public static bool IsValidKey(ConsoleKey consoleKey)
        {
            return validKeys.Contains(consoleKey);
        }

        public static void SetDone() => IsDone = true;
    }
}
