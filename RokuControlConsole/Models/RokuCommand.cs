using System;
using System.Collections.Generic;
using System.Text;

namespace RokuControlConsole.Models
{
    public class RokuCommand
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public ConsoleKey Key { get; set; }
    }
}
