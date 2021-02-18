using System;
using System.Collections.Generic;
using System.Text;

namespace TestWork
{
    public static class InputValidationService
    {
        private static bool IsInputCorrect(string input)
        {
            int maxSymbolsInBeginPacket = 2;
            int maxSymbolsInEndPacket = 1;
            var array = input.Split(':');

            if (array.Length == 3)
            {
                if (array[0].Length == maxSymbolsInBeginPacket)
                {
                    if (array[2].Length == maxSymbolsInEndPacket)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool CheckValidation(string input)
        {
            return IsBeginCharCorrect(input[0]) && IsSymbolsInRange(input) && IsInputCorrect(input);
        }

        private static bool IsBeginCharCorrect(char symbol)
        {
            return (int)ConsoleKey.P == symbol;
        }
        private static bool IsSymbolsInRange(string input)
        {
            bool result = true;
            int minValue = 32;
            int maxValue = 127;

            foreach (var item in input)
            {
                if (item < minValue || item > maxValue)
                    result = false;
            }

            return result;
        }
    }
}
