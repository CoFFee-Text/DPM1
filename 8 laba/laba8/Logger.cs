using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    public class Logger : Colleague
    {
        public void WriteMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n[LOG] {message}\n");
            Console.ResetColor();
        }
    }
}
