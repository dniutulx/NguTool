using System;
using System.Linq;
using NguTool;

namespace NguTool.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a command or \"help\" for a list of commands");

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "exit") break;

                if (string.IsNullOrEmpty(input)) continue;

                var result = Commands.Parse(input);

                Console.WriteLine($"({(result.Success ? "SUCCESS" : "ERROR")}): {result.Message}");
            };
        }
    }
}
