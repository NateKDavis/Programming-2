using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackLibrary
{
    public class Misc
    {
        #region ReadInteger
        public static int ReadInteger(string prompt, int min, int max)
        {
            bool valid = false;
            int readIntInput = 0;
            string errorMessage = $"Input was not between {min} and {max}!";

            // while loop to continue asking the user for a valid input
            while (valid == false)
            {
                Console.Write($"{prompt}");

                // if to check if input is a number within min and max
                if (int.TryParse(Console.ReadLine(), out readIntInput) && readIntInput >= min && readIntInput <= max)
                {
                    break;
                }

                // error message for user
                else
                {
                    Console.WriteLine($"{errorMessage}");
                }
            }

            return readIntInput;
        }
        #endregion


        #region ReadChoice Method
        public static void ReadChoice(string prompt, string[] options, out int selection)
        {
            int idx = 1;
            Console.WriteLine();

            // print each option in the given index
            foreach (string item in options)
            {
                Console.WriteLine($"Option {idx++}. {item}");
            }

            Console.WriteLine();

            // asks for and checks user's input. then saves it
            selection = ReadInteger(prompt, 1, options.Length);
        }
        #endregion
    }
}
