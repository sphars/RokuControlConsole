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
            ConsoleKey.UpArrow,
            ConsoleKey.DownArrow,
            ConsoleKey.LeftArrow,
            ConsoleKey.RightArrow,
            ConsoleKey.Enter,
            ConsoleKey.Spacebar,
            ConsoleKey.Backspace,
            ConsoleKey.OemPeriod,
            ConsoleKey.OemComma,
            ConsoleKey.M
        };

        public static void SetUrl(string ipAddress) => baseUrl = $"http://{ipAddress}:{port}/";

        public static bool IsValidKey(ConsoleKey consoleKey)
        {
            return validKeys.Contains(consoleKey);
        }

        public static void SetDone() => IsDone = true;
    }
}
