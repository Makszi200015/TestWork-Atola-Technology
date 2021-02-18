using System;
using System.Collections.Generic;
using System.Text;

namespace TestWork
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Start();
            }
        }
        static void Start()
        {
            var input = GetInput();

            Console.WriteLine();

            if (!InputValidationService.CheckValidation(input))
            {
                ResponseService.SendBadResponse();
                return;
            }

            ExecuteCommand(input);
        }
        static void ExecuteCommand(string input)
        {
            if (CommandService.ExecuteCommand(input))
                ResponseService.SendGoodResponse();
            else
                ResponseService.SendBadResponse();
        }
        static string GetInput()
        {
            StringBuilder s = new StringBuilder();
            char symbol;
            do
            {
                symbol = Console.ReadKey().KeyChar;
                s.Append(symbol);
            }
            while ((int)ConsoleKey.E != symbol);

            return s.ToString();
        }
    }
}
