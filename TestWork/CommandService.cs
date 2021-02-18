using System;
using System.Collections.Generic;
using System.Text;

namespace TestWork
{
    public static class CommandService
    {
        public delegate bool OutAction(string a);
        private static readonly Dictionary<char, OutAction> commandDictionary;
        static CommandService()
        {
            commandDictionary = new Dictionary<char, OutAction>();
            InitializeDictionary();
        }
        private static void InitializeDictionary()
        {
            commandDictionary.TryAdd('T', TextCommandExecute);
            commandDictionary.TryAdd('S', SoundCommandExecute);
        }

        public static bool ExecuteCommand(string input)
        {
            var commandSymbol = GetCommandCharacter(input);

            if (commandDictionary.TryGetValue(commandSymbol, out OutAction action))
            {
                return action.Invoke(input);
            }

            return false;
        }

        private static char GetCommandCharacter(string input)
        {
            return input[1];
        }

        private static bool TextCommandExecute(string input)
        {
            var array = input.Split(':');

            if (!IsTextParametersCountCorrect(array))
            {
                return false;
            }

            if (string.IsNullOrEmpty(array[1]))
            {
                Console.WriteLine("Fill the parameters");
                return false;
            }

            string text = array[1];

            Console.WriteLine(text);

            return true;
        }
        private static bool SoundCommandExecute(string input)
        {
            var array = input.Split(':');

            var parameters = array[1];
            var parametersArray = parameters.Split(',');

            if (!IsSoundParametersCountCorrect(parametersArray))
            {
                Console.WriteLine("Wrong parameters");
                return false;
            }

            if (!int.TryParse(parametersArray[0], out int frequency) || !int.TryParse(parametersArray[1], out int duration))
            {
                return false;
            }
            Console.Beep(frequency, duration);

            return true;
        }

        #region Validation methods

        private static bool IsSoundParametersCountCorrect(string[] parameters)
        {
            if (parameters.Length != 2)
            {
                return false;
            }

            return true;
        }
        private static bool IsTextParametersCountCorrect(string[] parameters)
        {
            if (parameters.Length != 3)
            {
                return false;
            }

            return true;
        }
        #endregion

    }
}